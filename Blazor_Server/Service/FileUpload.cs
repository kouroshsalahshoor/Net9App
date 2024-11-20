using Blazor_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using static NuGet.Packaging.PackagingConstants;

namespace Blazor_Server.Service;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<string> UploadFile(IBrowserFile file)
    {
        var fileInfo = new FileInfo(file.Name);
        var newFileName = Guid.NewGuid().ToString() + fileInfo.Extension;
        
        var folder = $"{_webHostEnvironment.WebRootPath}\\images\\products";
        if (Directory.Exists(folder) == false)
        {
            Directory.CreateDirectory(folder);
        }

        var path = Path.Combine(folder, newFileName);

        await using FileStream fs = new FileStream(path, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);

        var fullPath = $"/images/products/{newFileName}";
        return fullPath;
    }

    public bool DeleteFile(string filePath)
    {
        var fullPath = _webHostEnvironment.WebRootPath.Replace("\\","/") + filePath;
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return true;
        }
        return false;
    }
}
