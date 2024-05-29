using Azure.Storage.Blobs;
using FileProvider.Infrastructure.Contexts;
using Microsoft.Extensions.Logging;

namespace FileProvider.Services;

public class FileService(ILogger<FileService> logger, DataContext dataContext, BlobServiceClient blobServiceClient)
{
    private readonly ILogger<FileService> _logger = logger;
    private readonly DataContext _dataContext = dataContext;
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;


    public async Task SetBlobContainerAsync(string containerName)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        await container.CreateIfNotExistsAsync();
    }
}
