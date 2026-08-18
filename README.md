# LoopSlayer

A high-score game inspired by Loop Hero, developed as a university project for the Game Engines course at HTW Berlin.

## About the Project

LoopSlayer is a top-down, auto-battler game where you don't control the character directly—instead, you strategically purchase upgrades to maximize your score. The player automatically runs through an endless loop, engaging enemies that spawn periodically. The challenge is to survive as long as possible and set the highest score!

## Gameplay

Your character moves automatically through an endless loop. As enemies spawn, they engage in battle when they collide with you. Manage your resources by purchasing strategic upgrades like damage, multi-hit, HP regeneration, and more to defeat enemies and climb the leaderboard.

**Battle System:**
- Up to 4 enemies can fight you simultaneously
- Enemies spawn every few seconds (this interval can be reduced with upgrades)
- Battles occur automatically when you collide with enemies

## Features

- 🎮 **Strategic Upgrades**: Purchase upgrades to enhance damage, health, attack speed, and spawning frequency
- ⚔️ **Three Enemy Types**: Each with unique stats and behaviors
- 🔄 **Automatic Combat**: Turn-based enemy encounters without manual input
- 📊 **High Score Persistence**: Your best scores are saved locally
- 🛡️ **Stat Progression**: Combine additive and multiplicative upgrade effects for powerful builds
- ♾️ **Endless Gameplay**: Keep playing to beat your previous high score

## Enemies

| Enemy Type | Health | Attack Speed | Damage | Notes |
|------------|--------|--------------|--------|-------|
| **Slime** | Low | Slow | Low | Weakest enemy, good for early game |
| **Bat** | Very Low | Fast | Low-Medium | Fragile but quick attacks |
| **Rock** | High | Slow | Medium-High | Tanky opponent, deals significant damage |

## Controls

All controls are UI-based:
- **Mouse** to purchase upgrades
- **Spacebar/Button** to navigate menus

The character movement and combat are fully automatic.

## Technical Highlights

- 🔧 **Additive Scene Loading**: Seamless fight transitions without reloading the main scene
- 📦 **C# Data Classes**: Well-structured enemy and upgrade systems
- 🎲 **Spawn Manager**: Intelligent enemy spawning with configurable intervals
- 💾 **Persistence System**: Local high score storage
- 📈 **Upgrade System**: Flexible stat modifications using both additive and multiplicative operations

## Technical Stack

- **Engine**: Unity
- **Language**: C# (67.6%)
- **Shaders**: ShaderLab (26.9%) + HLSL (5.5%)

## What I Learned

- Working with additive scene loading
- Designing and implementing data classes for complex game objects (enemies, upgrades)
- The importance of access modifiers (private by default, explicit public when needed)
- Building scalable upgrade and stat systems

## Getting Started

1. Download the latest release from the [Releases](https://github.com/Rengowin/LoopSlayer/releases) page
2. Extract the ZIP file
3. Run the executable to start playing

**Note**: The game is currently available as a packaged release. No local build or compilation is required.

## Project History

The original project was developed during the Game Engines course from **September 20, 2025** to **November 16, 2025**. 

In **Summer 2026**, the project was revisited to:
- Improve UI scaling across different resolutions
- Fix various bugs
- Polish the overall experience

## Known Issues

- 🎮 The player spawns slightly above the board, causing the first loop counter to start at 1 instead of 0
- 🖥️ **UI Scaling**: The UI is optimized for 16:9 (1920×1080) and 16:10 resolutions
  - Ultra-wide resolutions (3440×1440) are not fully supported
- 🔘 The "Back to Main Menu" button placement could be improved
- ⚡ Attack speed stat might be more accurately named "Attack Cooldown"

## Screenshots

[Add gameplay screenshots here showing the main loop, battles, and upgrade shop]

[Add screenshot of the high score screen]

[Add screenshot of the pause/upgrade menu]

## Future Improvements

- [ ] Improve UI responsiveness for all aspect ratios
- [ ] Fix player spawn position
- [ ] Optimize attack stat naming/clarity
- [ ] Add visual feedback for upgrades
- [ ] Expand enemy variety and behaviors

---

**Developed by**: [Your Name]  
**Course**: Game Engines @ HTW Berlin  
**Year**: 2025-2026

Viel Spaß mit dem Spiel! 🎮
