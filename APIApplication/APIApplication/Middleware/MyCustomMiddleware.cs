namespace APIApplication.Middleware
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Before request goes to next middleware
            //Console.WriteLine("-----Request: " + context.Request.Headers["Authorization"].ToString());

            await _next(context); // Call the next middleware

            // After the response
            //Console.WriteLine("Response: " + context.Response.StatusCode);
        }
    }
}
