using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aquapets.Shared.Api.ActionFilterAttributes
{
    public sealed class StringifyModelErrorsAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new { message = string.Join(" ", errors) });
            }
            else
            {
                if (next != null)
                {
                    await next();
                }
            }

            
        }
    }
}
