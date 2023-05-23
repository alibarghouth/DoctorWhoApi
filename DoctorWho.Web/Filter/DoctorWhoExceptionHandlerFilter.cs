using DoctorWho.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorWho.Web.Filter;

public class DoctorWhoExceptionHandlerFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is DoctorWhoExceptions exception)
        {
            context.Result = new ObjectResult(new { exception.Message })
            {
                StatusCode = (int?)exception.StatusCode
            };

            context.ExceptionHandled = true;
        }
        else
        {
            base.OnException(context);
        }
    }
}
