using System.Net;

namespace Infrastructure.ApiResponse;

public class Responce<T>
{

    public Responce(T date)
    {
        Date = date;
        StatusCode = 200;
        Message = "";
    }

    public Responce(HttpStatusCode statusCode, string message)
    {
        Date = default;
        StatusCode = (int)statusCode;
        Message = message;
    }
    
    public int StatusCode { get; set; }
    public T? Date { get; set; }
    public string? Message { get; set; }
    
    
}