namespace WebServer.Common
{
    public class ApiResponse
    {
        public static readonly ApiResponse SUCCESS = new ApiResponse();

        public bool Success { get; set; }
        public ErrorCode ErrorCode { get; set; }
        // public string? Message { get; set; }
        public object? Data { get; set; }

        public ApiResponse()
        {
            Success = true;
            ErrorCode = ErrorCode.None;
            Data = null;
        }

        public ApiResponse(object data)
        {
            Success = true;
            ErrorCode = ErrorCode.None;
            Data = data;
        }
        public ApiResponse(ErrorCode errorCode)
        {
            Success = false;
            ErrorCode = errorCode;
            Data = null;
        }

        public ApiResponse(bool success, ErrorCode errorCode = ErrorCode.None, object? data = null)
        {
            Success = success;
            ErrorCode = errorCode;
            Data = data;
        }
    }
}
