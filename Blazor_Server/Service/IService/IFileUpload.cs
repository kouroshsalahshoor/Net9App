using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_Server.Service.IService;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile browserFile);
    bool DeleteFile(string filePath);
}
