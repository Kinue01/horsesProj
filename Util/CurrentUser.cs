using horsesProj.ModelV2;

namespace horsesProj.Util
{
    internal static class CurrentUser
    {
        public static TbUser User { get; set; }


        public static TbJockey Jokey { get; set; }
        public static TbJudge Judge { get; set; }
    }
}
