using System;

namespace DungeonPlanet
{
    public class Game
    {
        public static void Start()
        {
            Room[,] map = new Room[10, 10];
            GenerateMap(map);

            Player player1 = new Player();
            player1.X = 0;
            player1.Y = 0;

            map[player1.X, player1.Y].HasVisited = true;

            Console.WriteLine("Welcome to dungeon planet! ");
            Console.WriteLine("You are looking for the secret Key to escape! ");
            Console.WriteLine("What is your name?");
            player1.Name = Console.ReadLine();

            Console.WriteLine($"Press enter to Continue! ");
            Console.ReadLine();

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                DrawMap(map, player1);

                Room currentRoom = map[player1.X, player1.Y];
                Console.WriteLine($"You are at {player1.X},{player1.Y} | Room: {currentRoom.Description} | HP: {player1.Health} | Name: {player1.Name}");
                Console.WriteLine("Move (WASD) or Q to quit:");
                string command = Console.ReadLine().ToLower();

                if (command == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Thank You For Playing");
                    gameRunning = false;
                    continue;
                }

                player1.Move(command, map);
                currentRoom = map[player1.X, player1.Y];
                map[player1.X, player1.Y].HasVisited = true;

                if (currentRoom.HasEnemy)
                {
                    Console.Clear();
                    Console.WriteLine("\n--- COMBAT ---");
                    Enemy enemy = new Enemy();
                    Combat(player1, enemy, ref gameRunning);
                    currentRoom.HasEnemy = false;
                }

                if (currentRoom.IsGoal)
                {
                    Console.Clear();
                    Console.WriteLine("You have found the secret key!  GAMEOVER FOR NOW");
                    gameRunning = false;
                }
            }
        }
        public static void GenerateMap(Room[,] map)
        {
            Random rand = new Random();
            string[] roomDescription = { "Dark", "Dry", "Warm", "Wet", "Hot"};

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    map[x, y] = new Room();
                    int index = rand.Next(roomDescription.Length);
                    map[x, y].Description = roomDescription[index];
                    map[x, y].HasEnemy = rand.Next(100) < 15;
                    map[x, y].HadEnemy = map[x, y].HasEnemy;
                }
            }
            int goalX = rand.Next(map.GetLength(0));
            int goalY = rand.Next(map.GetLength(1));
            map[goalX, goalY].IsGoal = true;
        }
        public static void DrawMap(Room[,] map, Player player)
        {
            Console.WriteLine("\nMap:");

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("[P]");
                    }
                    else if (!map[x, y].HasVisited)
                    {
                        Console.Write("[ ]");
                    }
                    else if (map[x, y].HadEnemy)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write("[-]");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Combat(Player player, Enemy enemy, ref bool gameRunning)
        {
            Random rand = new Random();
            bool inCombat = true;
            while (inCombat)
            {
                Console.WriteLine($"The enemy has {enemy.Health} health");
                Console.WriteLine("Do you want to [F]ight or [R]un");
                string fof = Console.ReadLine().ToLower();

                if (fof == "f")
                {
                    int playerDamage = rand.Next(1, 4);
                    int enemyDamage = rand.Next(1, 4);

                    enemy.Health -= playerDamage;
                    Console.WriteLine($"You striked with {playerDamage} damage! ");

                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine("You defeated the enemy");
                        inCombat = false;
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        return;
                    }

                    player.Health -= enemyDamage;
                    Console.WriteLine($"The enemy strikes you for {enemyDamage} damage!");
                    Console.WriteLine($"You have {player.Health}");

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You died... GAME OVER.");
                        gameRunning = false;
                        break;
                    }
                }
                else if (fof == "r")
                {
                    bool escapeSucceeded = rand.Next(100) < 15;

                    if (escapeSucceeded)
                    {
                        Console.WriteLine("You ran!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        inCombat = false;
                    }
                    else
                    {
                        Console.WriteLine("Enemy hits again!");
                        player.Health--;
                        Console.WriteLine($"You have {player.Health} HP");
                    }
                }
            }
        }
    }
}
