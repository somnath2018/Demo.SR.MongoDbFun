using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DemoMongoDBProject.API.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private const string CORRELATIONID = "X-Correlation-ID";

        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var correlationId = Guid.NewGuid().ToString();

            if (httpContext.Request.Headers.ContainsKey(CORRELATIONID))
            {
                correlationId = httpContext.Request.Headers[CORRELATIONID].ToString();
            }

            httpContext.Response.OnStarting(state =>
            {
                if (httpContext.Response.Headers.ContainsKey(CORRELATIONID))
                {
                    httpContext.Response.Headers[CORRELATIONID] = correlationId;
                }
                else
                {
                    httpContext.Response.Headers.Add(CORRELATIONID, correlationId);
                }
                return Task.FromResult(0);
            }, httpContext);

            //using (ILogger.PushProperty(CORRELATIONID, correlationId))
            //{
            //    await _next(httpContext);
            //}
            await _next(httpContext);
        }
    }
}
