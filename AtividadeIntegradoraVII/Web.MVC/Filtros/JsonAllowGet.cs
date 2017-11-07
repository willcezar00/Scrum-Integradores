using System.Web.Mvc;

namespace Web.MVC.Filtros
{
    /// <summary>
    /// Esse filtro serve para poder retornar um obejto
    /// Json em um metodo POST sem resultar em um erro de
    /// JsonBehavior.AllowGet
    /// </summary>
    public sealed class JsonAllowGet : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            var jsonResult = context.Result as JsonResult;
            if (jsonResult == null) return;

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;
            if (jsonResult == null) return;

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.OnResultExecuting(filterContext);
        }
    }
}
