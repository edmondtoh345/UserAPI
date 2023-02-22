using FavouriteAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FavouriteAPI.Filters
{
    public class AppExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(FavNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(FavAlreadyExistsException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else
            {
                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
