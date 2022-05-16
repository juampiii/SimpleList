using Microsoft.Extensions.Logging;

namespace SimpleList.Application.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogCreationInformation(this ILogger logger, string typeName, int newId)
        {
            logger.LogInformation($"A new {typeName} with id {newId} was created");
        }

        public static void LogUpdateInformation(this ILogger logger, string typeName, int newId)
        {
            logger.LogInformation($"The entity of type '{typeName}' with id {newId} was updated");
        }
    }
}
