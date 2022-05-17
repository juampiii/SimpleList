using SimpleList.Application.Exceptions;

namespace SimpleList.Application.Utils.Validations
{
    public static class CommonGuardExtensions
    {
        public static void IsNull<T>(this IGuardClause guardClause, T entity, string? errorMessage = null)
        {
            if (entity != null)
                return;

            if (string.IsNullOrWhiteSpace(errorMessage))
                errorMessage = $"The item of type '{typeof(T).Name}' does not exist";

            throw new NotFoundException(errorMessage);
        }
    }
}
