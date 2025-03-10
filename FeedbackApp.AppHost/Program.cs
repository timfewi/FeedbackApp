using k8s.Models;

var builder = DistributedApplication.CreateBuilder(args);

// RedisCache
var cache = builder.AddRedis("cache").WithRedisCommander();

// Postgres DB
var db = builder
    .AddPostgres("db")
    .WithPgAdmin()
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent);

var api = builder.AddProject<Projects.FeedbackApp_ApiService>("api")
    .WithReference(db);

// NEXTJS frontend
var frontend = builder
    .AddNpmApp("frontend", "../FeedbackApp.Web", "dev")
    .WithNpmPackageInstallation()
    .WaitFor(api)
    .WithReference(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
