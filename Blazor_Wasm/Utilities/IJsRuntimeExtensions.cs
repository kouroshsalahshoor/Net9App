using Microsoft.JSInterop;

namespace Blazor_Wasm.Utilities
{
    public static class IJsRuntimeExtensions
    {
        public static async Task SwalSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showSwal", "success", message);
        }

        public static async Task SwalWarning(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showSwal", "warning", message);
        }

        public static async Task SwalError(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showSwal", "error", message);
        }

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
