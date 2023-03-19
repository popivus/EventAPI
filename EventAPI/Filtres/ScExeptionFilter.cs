using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SC.Internship.Common.Exceptions;
using SC.Internship.Common.ScResult;

namespace EventAPI.Exception_Filtres
{
    public class ScExeptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ScResult scResult = new ScResult();
            ScError scError = new ScError();
            scError.Message = context.Exception.Message;
            scResult.Error = scError;
            ObjectResult objectResult = new(scResult);
            objectResult.StatusCode = 500;
            context.Result = objectResult;
            throw new ScException(context.Exception, context.Exception.Message);
        }
    }
}
