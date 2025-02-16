using horsesProj.ModelV2;

namespace horsesProj.Util
{
    internal static class DatabaseConnection
    {
        public static HorsesV2Context ContextV2 { get; } = new();
    }
}
