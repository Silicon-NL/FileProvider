using Azure.Storage.Blobs;
using FileProvider.Infrastructure.Contexts;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using FileProvider.Infrastructure.Entities;
namespace FileProvider.Services;

public class FileService(ILogger<FileService> logger, DataContext dataContext, BlobServiceClient blobServiceClient)
{
    private readonly ILogger<FileService> _logger = logger;
    private readonly DataContext _dataContext = dataContext;
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private BlobContainerClient _containerClient;


    public async Task SetBlobContainerAsync(string containerName)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);
        await container.CreateIfNotExistsAsync();
    }

    public string SetFileName(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        return fileName ;
    }

    public async Task<string> UploadFileAsync(IFormFile file, FileEntity fileEntity)
    {
        BlobHttpHeaders headers = new BlobHttpHeaders()
        {
            ContentType = file.ContentType
        };

        var blobClient = _containerClient.GetBlobClient(fileEntity.FileName);
        using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, headers);

        return blobClient.Uri.ToString();
    }

    public async Task SaveToDatabaseAsync(FileEntity fileEntity)
    {
        _dataContext.Add(fileEntity);
        await _dataContext.SaveChangesAsync();
    }
}
