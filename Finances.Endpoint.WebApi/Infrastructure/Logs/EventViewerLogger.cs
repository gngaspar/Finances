// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventViewerLogger.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The event viewer logger.
// </summary>W
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.Infrastructure.Logs
{
    using System;
    using System.Configuration;
    using System.Diagnostics;

    using Finances.Domain;

    using Newtonsoft.Json;

    /// <summary>
    /// The event viewer logger.
    /// </summary>
    public static class EventViewerLogger
    {
        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex">
        /// The exception.
        /// </param>
        public static void LogException( Exception ex )
        {
            if ( ex == null )
            {
                return;
            }

            var logSource = ConfigurationManager.AppSettings[ "EventViewerLogger.Source" ];
            var logEnable = false;
            bool.TryParse( ConfigurationManager.AppSettings[ "EventViewerLogger.Enabled" ], out logEnable );
            if ( !logEnable )
            {
                return;
            }

            try
            {
                EventLog.WriteEntry(
                    logSource,
                    JsonConvert.SerializeObject( ex, Formatting.Indented ),
                    EventLogEntryType.Error );
            }
            catch
            {
                // do nothing it just save log
            }
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex">
        /// The exception.
        /// </param>
        public static void LogException( FinancesException ex )
        {
            if ( ex == null )
            {
                return;
            }

            var logSource = ConfigurationManager.AppSettings[ "EventViewerLogger.Source" ];
            var logEnable = false;
            bool.TryParse( ConfigurationManager.AppSettings[ "EventViewerLogger.Enabled" ], out logEnable );
            if ( !logEnable )
            {
                return;
            }

            try
            {
                EventLog.WriteEntry(
                    logSource,
                    JsonConvert.SerializeObject( ex, Formatting.Indented ),
                    EventLogEntryType.Error );
            }
            catch
            {
                // do nothing it just save log
            }
        }
    }
}