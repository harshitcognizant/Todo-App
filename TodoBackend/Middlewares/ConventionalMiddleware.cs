using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TodoBackend.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ConventionalMiddleware
	{
		private readonly RequestDelegate _next;

		public ConventionalMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			httpContext.Response.Headers["ConventionalMiddleware"] = "ConventionalMiddleware";
			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ConventionalMiddlewareExtensions
	{
		public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ConventionalMiddleware>();
		}
	}
}
