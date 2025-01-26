using horsesProj.Model;

namespace horsesProj.UIModel
{
    internal class CompetRides
    {
        public DateTime CompetDate { get; set; }

        public string CompetName { get; set; } = null!;

       public List<TbRide> Rides { get; set; }
    }
}
