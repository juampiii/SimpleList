namespace SimpleList.Application.Utils.Validations
{
    public interface IGuardClause
    {
    }

    public class Guard : IGuardClause
    {
        public static IGuardClause Against { get; } = new Guard();
        private Guard() { }
    }
}
