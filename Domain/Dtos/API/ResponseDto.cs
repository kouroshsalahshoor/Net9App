namespace Domain.Dtos.API;

public class ResponseDto
{
    public bool IsSuccessful { get; set; } = true;
    public string Message { get; set; }
    public object? Data { get; set; }
}
