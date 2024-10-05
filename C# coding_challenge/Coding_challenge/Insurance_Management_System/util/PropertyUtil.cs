using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.util
{
    internal class PropertyUtil
    {
        private static IConfiguration _iconfiguration;

        static PropertyUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                         .AddJsonFile("C:\\Users\\Srishti Seth\\Documents\\Codingchallenge\\Coding_challenge\\Insurance_Management_System\\AppSetting.json");
            _iconfiguration = builder.Build();
        }

        public static string getPropertyString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
