using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FileProvider.Functions;

public class Upload(ILogger<Upload> logger)
{
    private readonly ILogger<Upload> _logger = logger;

    [Function("Upload")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        
    }
}
