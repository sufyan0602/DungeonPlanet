

namespace DungeonPlanet
{

    public class Room
    {
        public bool HasVisited { get; set; }
        public bool HasEnemy { get; set; }
        public bool HadEnemy { get; set; }
        public bool IsGoal { get; set; }
        public string Description { get; set; }
    }
}