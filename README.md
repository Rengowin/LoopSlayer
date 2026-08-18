# LoopSlayer

A high-score game inspired by Loop Hero, developed as a university project for the Game Engines course at HTW Berlin.


### **Gane Board**
<img width="1919" height="1079" alt="GameBoard" src="https://github.com/user-attachments/assets/8cfffd33-0ea2-4ce4-b63e-24f5963baf92" />

## About the Project

LoopSlayer is a top-down, auto-battler game where you don't control the character directly—instead, you strategically purchase upgrades to maximize your score. The player automatically runs through an endless loop, engaging enemies that spawn periodically. The challenge is to survive as long as possible and set the highest score!

## Gameplay

Your character automatically moves around an endless loop. Enemies spawn on the board and initiate an automatic battle when they collide with the player. Defeating enemies rewards score and upgrade points.

Upgrade points can be used to improve player stats such as health, damage and attack speed, or to modify enemy spawning and scaling. Enemy stats increase with each completed loop, making encounters progressively more difficult.

**Battle System:**
- Up to 4 enemies can fight you simultaneously
- Enemies spawn every few seconds (this interval can be reduced with upgrades)
- Battles occur automatically when you enter the collide with enemies

### **Shop**
<img width="1919" height="1079" alt="Screenshot 2026-08-18 191502" src="https://github.com/user-attachments/assets/cd2962d0-b091-441c-8bef-a961301737fc" />

### **Fight**
<img width="1919" height="1077" alt="FightScene" src="https://github.com/user-attachments/assets/cb27c30f-bba7-4a8e-a81a-721883d0787b" />

## Features

- **Strategic Upgrades**: Purchase upgrades to enhance damage, health, attack speed, and spawning frequency
- **Three Enemy Types**: Each with different stats
- **Automatic Combat**: Turn-based enemy encounters without manual input
- **High Score Persistence**: Your best scores are saved locally
- **Stat Progression**: Using additive and multiplicative stat modifications to buff yourself
- **Endless Gameplay**: Keep playing to beat your previous high score

## Enemies

| Enemy Type | Health | Damage | Attack Cooldown | Score |
|------------|--------|--------------|--------|-------|
| **Slime** | 20 | 2 | 5 | 100 |
| **Bat** | 15 | 2 | 2 | 175 |
| **Rock** | 60 | 5 | 7 | 250 |

Enemy stats are multiplied by 1.15 each loop.

## Controls

All controls are UI-based:
- **Mouse** to purchase upgrades

The character movement and combat are fully automatic.

## Technical Highlights

- **Additive Scene Loading**: The fight scene is loaded additively while keeping the main game board loaded.
- **C# Data Classes**: For enemy and upgrade data
- **Spawn Manager**: Every 10 seconds, an enemy has a chance to spawn on a path tile.
- **Persistence System**: Local high score storage
- **Upgrade System**: Flexible stat modifications using both additive and multiplicative operations

## Technical Stack

- **Engine**: Unity
- **Language**: C# 

## What I Learned

- Working with additive scene loading
- Designing and implementing data classes for complex game objects (enemies, upgrades)
- Working with C# access modifiers and their default behavior (not having to explicitly write private everywhere was a nice discovery).

## Getting Started

1. Download the latest release from the [Releases](https://github.com/Rengowin/LoopSlayer/releases) page
2. Extract the ZIP file
3. Run the executable to start playing

**Note**: The game is currently available as a packaged release. No local build or compilation is required.

## Project History

The original project was developed during the Game Engines course from **October 2025** to **November 16, 2025**. 

In **Summer 2026**, the project was revisited to:
- Improve UI scaling across different resolutions
- Fix various bugs
- Polish the overall experience

## Known Issues

- The player spawns slightly above the board, causing the first loop counter to start at 1 instead of 0
- **UI Scaling**: The UI is optimized for 16:9 (1920×1080) and 16:10 resolutions
  - Ultra-wide resolutions (3440×1440) are not fully supported
- The "Back to Main Menu" button placement could be improved
- Attack speed stat might be more accurately named "Attack Cooldown"


---

**Developed by**: [Winde, Benjamin \ RengoWin]  
**Course**: Game Engines @ HTW Berlin  
**Year**: Developed 2025, revisited 2026

Have fun playing
