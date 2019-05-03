using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neudesic.KeyVaultManager;

namespace KeyVaultManagerApp
{
    class Program
    {
        public const string ClientID = "";//APPID
        public const string VaultUrl = "";//KeyVaultURL
        public const string ClientSecret = "";//App Secret

        static void Main(string[] args)
        {
            KeyVaultHandler keyVaultHandler = new KeyVaultHandler(VaultUrl, ClientID, ClientSecret);
            Console.WriteLine(keyVaultHandler.GetKeyVaultKey("test"));
            //keyVaultHandler.CreateKeyVaultKey("test", "RSA", 2048);

        }
    }
}
