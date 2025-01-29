const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(";")[0]
  : "https://localhost:7251";

const PROXY_CONFIG = [
  {
    context: ["/api"], // Proxy only requests that start with `/api`
    target: target,
    secure: false,
    changeOrigin: true,
  },
];

module.exports = PROXY_CONFIG;
