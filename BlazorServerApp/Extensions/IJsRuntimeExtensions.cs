using Microsoft.JSInterop;

namespace BlazorServerApp.Extensions
{
    public static class IJsRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showToastr", "success", message);
        }

        public static async Task ToastrWarning(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showToastr", "warning", message);
        }

        public static async Task ToastrError(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showToastr", "error", message);
        }
    }
}
