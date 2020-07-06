using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Logging
{
    public static class Logger
    {
        public static void LogInfomation(string message, params object[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddLog4Net();
            });
            var log = loggerFactory.CreateLogger("Logger");
            log.LogInformation(message, args);
        }
        public static void LogDebug(string message, params object[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddLog4Net();
            });
            var log = loggerFactory.CreateLogger("Logger");
            log.LogDebug(message, args);
        }
        public static void LogError(string message, params object[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddLog4Net();
            });
            var log = loggerFactory.CreateLogger("Logger");
            log.LogError(message, args);
        }
    }
}
