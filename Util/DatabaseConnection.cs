using horsesProj.Model;

namespace horsesProj.Util
{
    internal static class DatabaseConnection
    {
        public static readonly HorsesContext context = new();
    }
}
