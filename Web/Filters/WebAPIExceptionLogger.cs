using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Web.Filters
{
    public class WebAPIExceptionLogger : ExceptionLogger
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            logger.Fatal(context.ExceptionContext.Exception);

            base.Log(context);
        }

    }
}