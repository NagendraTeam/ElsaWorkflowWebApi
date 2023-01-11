using Azure.Core;
using ElsaWorkflowDesigner.Models;
using ElsaWorkflowDesigner.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace ElsaWorkflowDesigner.Controllers
{
    public class DesignerController : Controller
    {
        HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        RequestBudgetJsonData request = new RequestBudgetJsonData();
        public IActionResult Index(string requestedBy, string requestId)
        {
            string scheme = httpContextAccessor.HttpContext.Request.Scheme;
            string host = httpContextAccessor.HttpContext.Request.Host.ToString();

            request.RequestedBy = requestedBy;
            request.serverUrl = scheme + "://" + host;

            //ViewBag.serverUrl = scheme + "://" + host;
            return View(request);
        }

       
    }
}
