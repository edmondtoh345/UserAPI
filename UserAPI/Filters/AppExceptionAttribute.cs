using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserAPI.Exceptions;

namespace UserAPI.Filters
{
    public class AppExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UserNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(UserAlreadyExistsException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else if (exceptionType == typeof(InvalidCredentialsException))
            {
                context.Result = new UnauthorizedObjectResult(message);
            }
            else
            {
                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
