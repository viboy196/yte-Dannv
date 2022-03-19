using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Xcomp.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
               throw new ValidationException(context.ModelState.GetErrors());
            }
        }
    }

    public static class ModelStateExtensions
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var state in modelState)
            {
                stringBuilder.AppendJoin('\n', state.Value.Errors
                    .Select(error => error.ErrorMessage));
            }

            return stringBuilder.ToString();
        }
    }
}
