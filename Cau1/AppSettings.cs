using System;
using System.Collections.Generic;
using System.Text;

namespace Cau1
{
    public class AppSettings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; } = new();
        public LoggingSettings Logging { get; set; } = new();
    }

    public class ConnectionStringsSettings
    {
        public string DefaultConnection { get; set; } = "";
    }

    public class LoggingSettings
    {
        public string MinimumLevel { get; set; } = "Information";
    }
}
