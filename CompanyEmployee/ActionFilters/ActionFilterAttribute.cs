using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyEmployee.ActionFilters
{
    public abstract class ActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
