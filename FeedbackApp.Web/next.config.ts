import type { NextConfig } from 'next';

import initializeBundleAnalyzer from '@next/bundle-analyzer';

// https://www.npmjs.com/package/@next/bundle-analyzer
const withBundleAnalyzer = initializeBundleAnalyzer({
    enabled: process.env.BUNDLE_ANALYZER_ENABLED === 'true'
});

const API_URL = process.env["services__api__https__0"];

// https://nextjs.org/docs/pages/api-reference/next-config-js
const nextConfig: NextConfig = {
    async rewrites() {
        return [
          {
            source: "/:path*",
            destination: `${API_URL}/:path*`,
          },
        ];
      },
    output: 'standalone',
    outputFileTracingIncludes: {
        "/*": ["./registry/**/*"],
      },
      images: {
        remotePatterns: [
          {
            protocol: "https",
            hostname: "avatars.githubusercontent.com",
          },
          {
            protocol: "https",
            hostname: "images.unsplash.com",
          },
        ],
      },

};

export default withBundleAnalyzer(nextConfig);
