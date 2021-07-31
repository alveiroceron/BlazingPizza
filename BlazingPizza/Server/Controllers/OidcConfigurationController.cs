using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Controllers
{
    public class OidcConfigurationController : Controller
    {
        readonly ILogger<OidcConfigurationController> Logger;
        readonly IClientRequestParametersProvider ClientRequestParametersProvider;

        public OidcConfigurationController(IClientRequestParametersProvider provider, ILogger<OidcConfigurationController> logger) =>
            (Logger, ClientRequestParametersProvider) = (logger, provider);


        [HttpGet("_configuration/{clientid}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            var Parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(Parameters);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
