namespace Web.Renderer
{
    using System;
    using System.Text;
    using System.Threading;
    using Common.Security;
    using NLog;
    using NLog.Config;
    using NLog.LayoutRenderers;

    [LayoutRenderer("accountId")]
    [ThreadAgnostic]
    public class AccountIdLayoutRenderer : LayoutRenderer
    {

        /// <summary>
        /// Renders the current ApplicantId.
        /// </summary>
        /// <param name="builder">String Builder</param>
        /// <param name="logEvent">Logging Event</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var customPrincipal = Thread.CurrentPrincipal as ICustomPrincipal;

            builder.Append(customPrincipal?.AccountId ?? Guid.Empty);
        }

    }
}