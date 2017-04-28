using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected static ILogger logger = LogManager.GetCurrentClassLogger();

    }
}