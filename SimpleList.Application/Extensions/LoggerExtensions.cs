using Microsoft.Extensions.Logging;
using SimpleList.Domain.Common;

namespace SimpleList.Application.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogBaseDomainModelCreation<T>(this ILogger logger, int newId) where T : BaseDomainModel
        {
            logger.LogInformation($"A new '{typeof(T).Name}' with id {newId} was created");
        }

        public static void LogBaseDomainModelUpdate<T>(this ILogger logger, int id) where T : BaseDomainModel
        {
            logger.LogInformation($"The entity of type '{typeof(T).Name}' with id {id} was updated");
        }

        public static void LogBaseDomainModelDelete<T>(this ILogger logger, int id) where T : BaseDomainModel
        {
            logger.LogInformation($"The entity of type '{typeof(T).Name}' with id {id} was deleted");
        }
    }
}
