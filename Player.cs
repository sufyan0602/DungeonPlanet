using System;

namespace DungeonPlanet
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 20;
        public int X { get; set; }
        public int Y { get; set; }
        public void Move(String direction, Room[,] map)
        {
            if (direction == "w")
            {
                if (Y > 0)
                {
                    Y--;
                }
                else
                {
                    Console.WriteLine("You have hit a wall");
                }
            }
            else if (direction == "s")
            {
                if (Y < map.GetLength(1) - 1)
                {
                    Y++;
                }
                else
                {
                    Console.WriteLine("You have hit a wall");
                }

            }
            else if (direction == "a")
            {
                if (X > 0)
                {
                    X--;
                }
                else
                {
                    Console.WriteLine("You have hit a wall");
                }
            }
            else if (direction == "d")
            {
                if (X < map.GetLength(0) - 1)
                {
                    X++;
                }
                else
                {
                    Console.WriteLine("You have hit a wall");
                }
            }
            else
            {
                Console.WriteLine("INVALID");
            }
        }
    }
}