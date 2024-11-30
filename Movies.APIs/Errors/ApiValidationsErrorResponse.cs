namespace Movies.PL.APIs.Errors
{
    public class ApiValidationsErrorResponse:ApiResponse
    {
        public List<string> Errors { get; set; }
        public ApiValidationsErrorResponse():base(400)
        {
           
        }

    }
}
