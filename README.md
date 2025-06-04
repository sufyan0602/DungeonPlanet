# 🪐 DungeonPlanet

**DungeonPlanet** is a turn-based, text-based dungeon crawler built in C#. Explore a procedurally generated world, battle enemies, and search for the hidden goal — all while managing your health and avoiding traps.

---

## 🎮 Features

- 🌍 Dynamically sized world map (user-defined)
- 🧭 Movement using `W`, `A`, `S`, `D` keys
- 👾 Turn-based combat system
- ❓ Procedurally generated rooms with randomized descriptions
- 🎯 Secret goal hidden somewhere in the dungeon
- 💀 Enemy encounters with damage and escape options
- 📜 Persistent room states (visited, enemy defeated)

---

## 🧱 Architecture

- `Game.cs`: Main game loop, combat system, and map generation
- `Player.cs`: Handles player movement and stats
- `Enemy.cs`: Defines enemy stats
- `Room.cs`: Stores room data (description, enemy presence, goal)

---

## 🧠 What I Learned

- Object-oriented programming in C#
- Console rendering of 2D maps
- Game loop logic
- Procedural content generation
- Handling state across user input

---

## 🛠 Tech Stack

- C# (.NET Console App)
- .NET Core / .NET 6+
- Visual Studio or VS Code

---

## 🚀 Getting Started

1. Clone this repository  
2. Open the solution in Visual Studio or any C# IDE  
3. Build and Run!

```bash
git clone https://github.com/your-username/DungeonPlanet.git
