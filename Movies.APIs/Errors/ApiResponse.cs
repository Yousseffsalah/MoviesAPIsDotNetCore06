namespace Movies.PL.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponse(int statusCode,string? message =null) {

            StatusCode = statusCode;
            ErrorMessage = message ?? GetErrorMessegeForStatusCode(statusCode);

        }

        private string? GetErrorMessegeForStatusCode(int statusCode)
        {

            return statusCode switch {
                400 => "bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resourse not found",
                500 => "internal error",
                _ => null
            };
        }
    }
}
