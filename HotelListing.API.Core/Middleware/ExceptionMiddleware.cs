using HotelListing.API.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace HotelListing.API.Core.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) 
        {
			this._next = next;
			this._logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occered while processing {context.Request.Path}");
				await HandleExceptionAsynk(context, ex);
			}
		}

		private Task HandleExceptionAsynk(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";
			HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
			var errorDetails = new ErrorDetails
			{
				ErrorType = "Failure",
				ErrorMessage = ex.Message
			};

			switch(ex)
			{
				case NotFoundException notFoundExceeption:
					httpStatusCode = HttpStatusCode.NotFound;
					errorDetails.ErrorType = "Not Found";
					break;
				default:
					break;
			}

			string respons = JsonConvert.SerializeObject(errorDetails);
			context.Response.StatusCode = (int)httpStatusCode;
			return context.Response.WriteAsync(respons);
		}
	}

	public class ErrorDetails
	{
		public string ErrorMessage { get; set; }
		public string ErrorType { get; set; }
	}
}
