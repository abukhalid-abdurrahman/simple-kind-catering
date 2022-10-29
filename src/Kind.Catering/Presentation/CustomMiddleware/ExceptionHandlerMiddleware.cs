using System.Threading.Tasks;
using Kind.Catering.CrossCuttingConcerns.InternalException;
using Kind.Catering.Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kind.Catering.Presentation.CustomMiddleware
{
    public sealed class ExceptionHandlerMiddleware : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exceptionResponse = new Response<object>();
            int httpStatusCode;
            switch (context.Exception)
            {
                case BadRequestException badRequestException:
                    exceptionResponse.Message = badRequestException.Message;
                    exceptionResponse.Payload = null;
                    httpStatusCode = 400;
                    break;
                default:
                    exceptionResponse.Message = $"Internal Server Error! {context.Exception.Message}";
                    exceptionResponse.Payload = null;
                    httpStatusCode = 500;
                    break;
            }
            context.Result = new JsonResult(exceptionResponse);
            context.HttpContext.Response.StatusCode = httpStatusCode;
            return Task.CompletedTask;
        }
    }
}