using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationKeyVaultTest.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

            try
            {
                //var keyVaultClient = new KeyVaultClient(
                //    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                //var secret = await keyVaultClient.GetSecretAsync("https://kv6.vault.azure.net/secrets/secret")
                //    .ConfigureAwait(false);

                //var secrets = await keyVaultClient.GetSecretsAsync("https://kv1mert.vault.azure.net/");



                //await keyVaultClient.SetSecretAsync("https://kv1mert.vault.azure.net/", "test2", "oley");
                //var secret2 = await keyVaultClient.GetSecretAsync("https://kv6.vault.azure.net/secrets/test2");
                // var secret = await keyVaultClient.GetSecretAsync("https://kv61.vault.azure.net/secrets/test/234584487ce449c482e75b46a5837a80");
                //ViewBag.Secret = $"Secret: {secrets.First().Id} + {secrets.ElementAt(1).Id}";
                //ViewBag.Secret2 = $"Secret: {secret2.Value}";
                //var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                //var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
                //Nethereum.Web3.Accounts.Account account = new Nethereum.Web3.Accounts.Account("0x7b6612e69adf30b586aec352010cc521b241e85ba72369fb922c2cf654b18762");
                var senderAddress = "0x611F4b562CdBDB23cD1d474A7b8047d3eaF9E929";
                var password = "ebenEBEN11";

                var account = new ManagedAccount(senderAddress, password);
                //var web3 = new Web3.Web3(account);
                var web3 = new Nethereum.Web3.Web3("http://ethdacaxlaox.eastus.cloudapp.azure.com:8545/");
                //web3.Eth.DeployContract.SendRequestAsync()
                var t = await web3.TransactionManager.SendTransactionAsync(account.Address, "0x087fa189f4749a879e1282863e7dbda280f7f0cb", new HexBigInteger(20));
                ViewBag.Secret = t;
            }
            catch (Exception exp)
            {
                ViewBag.Error = $"Something went wrong: {exp}";
            }

            //ViewBag.Principal = azureServiceTokenProvider.PrincipalUsed != null ? $"Principal Used: {azureServiceTokenProvider.PrincipalUsed}" : string.Empty;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DeployContract()
        {
            ViewBag.Message = "Deploy Contract";
            return View();
        }
    }
}