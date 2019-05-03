using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Neudesic.KeyVaultManager
{
    public class ConfigHelper
    {
        /// <summary>
        /// Returns the AppSettings value from App.Config file
        /// </summary>
        /// <param name="Key">AppSettinngs Key</param>
        /// <returns></returns>
        public static string GetConfigurationValue(string Key)
        {
            return Environment.GetEnvironmentVariable(Key);
        }
    }
}
