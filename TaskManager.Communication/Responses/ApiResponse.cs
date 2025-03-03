namespace TaskManager.Communication.Responses;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }

    public ApiResponse(bool isSuccess, string message = "", T data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public static ApiResponse<T> Success()
    {
        return new ApiResponse<T>(true);
    }

    public static ApiResponse<T> Success(string message, T data = default)
    {
        return new ApiResponse<T>(true, message, data);
    }

    public static ApiResponse<T> Failure(string message)
    {
        return new ApiResponse<T>(false, message);
    }
}