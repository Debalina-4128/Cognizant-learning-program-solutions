using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson_3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private static readonly object _lockObj = new object();

        public void OnException(ExceptionContext context)
        {
            var logsDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logsDir); // Ensure directory exists

            var errorPath = Path.Combine(logsDir, "errors.txt");

            var logMessage = $@"
[{DateTime.Now}]
Message: {context.Exception.Message}
StackTrace: {context.Exception.StackTrace}
--------------------------------------------------";

            lock (_lockObj)
            {
                File.AppendAllText(errorPath, logMessage + Environment.NewLine);
            }

            context.Result = new ObjectResult("An internal error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
