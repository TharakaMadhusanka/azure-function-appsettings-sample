using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionAppSettings
{
    public class FunctionAppSettings
    {
        private readonly AppSettingsConfigurationOptions _appSettingsConfigurationOptions;

        public FunctionAppSettings(IOptions<AppSettingsConfigurationOptions> configurationOptions)
        {
            _appSettingsConfigurationOptions = configurationOptions.Value;
        }

        [FunctionName("FunctionAppSettings")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = _appSettingsConfigurationOptions.Environment;

            return new OkObjectResult(responseMessage);
        }
    }
}
