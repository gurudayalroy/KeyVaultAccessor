using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neudesic.KeyVaultManager
{
    public class KeyVaultHandler
    {
        private string vaultUrl;
        private string clientId;
        private string clientSecret;
        private KeyVaultClient keyVaultClient;


        public KeyVaultHandler(string vaultUrl, string clientId, string clientSecret)
        {
            this.vaultUrl = vaultUrl;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(
             (authority, resource, scope) => GetAccessToken(authority, resource, scope)));
        }
        public KeyVaultHandler()
        {
            this.vaultUrl = ConfigHelper.GetConfigurationValue("VaultUrl");
            this.clientId = ConfigHelper.GetConfigurationValue("ClientId");
            this.clientSecret = ConfigHelper.GetConfigurationValue("ClientSecret");
        }
        public async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var clientCredential = new ClientCredential(clientId, clientSecret);
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }
        /// <summary>
        /// Retrieve keyvault secret value
        /// </summary>
        /// <param name="secretName">KeyVault secret name</param>
        /// <returns>KeyValut Secret value</returns>
        public string GetSecret(string secretName)
        {
            try
            {
                return keyVaultClient.GetSecretAsync(vaultUrl, secretName).GetAwaiter().GetResult()?.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates KeyVault Key
        /// </summary>
        /// <param name="KeyName">KeyVault Key Name</param>
        /// <param name="KeyType">KeyVault Key Type - (RSA,EC)</param>
        /// <param name="Size">KeyVault Key Size - (2048,3072,4096)</param>
        public void CreateKeyVaultKey(string KeyName, string KeyType,int? Size)
        {
           keyVaultClient.CreateKeyAsync(vaultUrl, KeyName, KeyType, Size).GetAwaiter().GetResult();
        }

        public void ImportKeyVaultKey()
        {
            //keyVaultClient.ImportKeyAsync()
        }

        public string GetKeyVaultKey(string key)
        {
            return keyVaultClient.GetKeyAsync(vaultUrl,key).GetAwaiter().GetResult().KeyIdentifier.Identifier;
        }

        public List<string> GetAllSecrets(List<string> secretsName)
        {
            List<string> data = new List<string>();
            
            return data;
        }
    }
}
