
var builder = DistributedApplication.CreateBuilder(args);

// RedisCache
var redis = builder.AddRedis("redis").WithRedisCommander();

// Postgres
var postgres = builder
    .AddPostgres("postgres")
    .WithImageTag("latest")
    .WithPgAdmin()
    .WithLifetime(ContainerLifetime.Persistent);

// Database's
var domainDb = postgres.AddDatabase("db");
var identityDb = postgres.AddDatabase("identitydb");

// Identity Server
var identity = builder.AddProject<Projects.FeedbackApp_Identity>("identity")
    .WithReference(identityDb)
    .WithExternalHttpEndpoints();

// Domain API
var api = builder.AddProject<Projects.FeedbackApp_ApiService>("api")
    .WithReference(redis)
    .WithReference(domainDb);

// NEXTJS frontend
var frontend = builder
    .AddNpmApp("frontend", "../FeedbackApp.Web", "dev")
    .WithNpmPackageInstallation()
    .WaitFor(api)
    .WithReference(api)
    .WithReference(identity)
    .WithHttpEndpoint(3000, env: "PORT")
    //.WithHttpsEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.FeedbackApp_Identity>("feedbackapp-identity");

builder.Build().Run();
