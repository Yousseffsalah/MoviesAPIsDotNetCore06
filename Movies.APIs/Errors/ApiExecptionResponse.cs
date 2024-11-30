namespace Movies.PL.APIs.Errors
{
    public class ApiExecptionResponse:ApiResponse
    {
        public string  Details { get; set; }
        public ApiExecptionResponse(int code =500, string messege = null,string details =null):base(code,messege)
        {
            this.Details = details;
        }
    }
}
