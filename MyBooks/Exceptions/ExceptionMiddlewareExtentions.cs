using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using MyBooks.Data.ViewModels;
using System.Net;

namespace MyBooks.Exceptions
{
	public static class ExceptionMiddlewareExtentions //extention method for the IApplication builder interface
	{
		public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					var logger = loggerFactory.CreateLogger("ConfigureBuildInExceptionHandler");
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/jason";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					var contextRequest = context.Features.Get<IHttpRequestFeature>();

					if (contextFeature != null)
					{
						var errorVMString = new ErrorVM()
						{
							StatusCode = context.Response.StatusCode,
							Message = contextFeature.Error.Message,
							Path = contextRequest.Path
						}.ToString();

						logger.LogError(errorVMString);
						await context.Response.WriteAsync(errorVMString);
					}
				});
			});
		}

		public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
		{
			app.UseMiddleware<CustomExceptionMiddleware>();

		}
	}
}
