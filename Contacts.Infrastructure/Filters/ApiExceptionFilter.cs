using Contacts.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Contacts.Infrastructure.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {


        /// <summary>
        /// An custom filter which is being called by <see cref="ExceptionFilterAttribute.OnExceptionAsync"/> method.
        /// NOTE: No need to override OnExceptionAsync method, as mentioned on official documentation.
        /// </summary>
        /// <param name="context">The <see cref="ExceptionContext" />.</param>
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ContactNotFoundException exception:
                    {
                        context.Result = new NotFoundObjectResult(exception.Message);
                    }
                    break;
                case DuplicatedContactException exception:
                    {
                        context.Result = new BadRequestObjectResult(exception.Message);
                    }
                    break;
                case InvalidCredentialsException exception:
                    {
                        context.Result = new BadRequestObjectResult(exception.Message);
                    }
                    break;
                case RequiredFieldException exception:
                    {
                        context.Result = new BadRequestObjectResult(exception.Message);
                    }
                    break;
                case BusinessException exception:
                    {
                        var validation = new
                        {
                            Status = 400,
                            Title = "Bad Request",
                            Detail = exception.Message
                        };
                        var json = new
                        {
                            errors = new[] { validation }
                        };
                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.ExceptionHandled = true;
                    }
                    break;
            }

            base.OnException(context);
        }
    }
}
