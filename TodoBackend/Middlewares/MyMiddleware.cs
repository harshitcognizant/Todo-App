namespace TodoBackend.Middlewares
{
	public class MyMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			context.Response.Headers["NormalMiddleware"] = "NormalMiddleware";
			context.Response.Cookies.Append("cookie","120010");
			await next(context);
		}
	}
}
