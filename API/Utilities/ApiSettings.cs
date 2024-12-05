namespace API.Utilities
{
    public class ApiSettings
    {
        public string SecretKey { get; set; } = default!;
        public string ValidAudience { get; set; } = default!;
        public string ValidIssuer { get; set; } = default!;
    }
}
