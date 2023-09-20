using User.Host.MyUtilities;

namespace User.Host.Infrastructure
{
	public static class ExceptionMiddleware
	{
		public static async Task Handle(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				var message = Utilities.WriteLogs(ex);

				context.Response.StatusCode = StatusCodes.Status400BadRequest;

				await context.Response.WriteAsync(message);
			}
		}
	}
}
