# Driver Dash

Driver Dash is a 2D top-down racing game that showcases driving logic, collision handling, boosts, drifting, and interaction with the environment.

## Gameplay

- Control your car using the W/A/S/D keys (or arrow keys):
  - W / Up Arrow: Accelerate forward
  - S / Down Arrow: Reverse / Brake
  - A / Left Arrow: Steer left
  - D / Right Arrow: Steer right
- Combine forward/reverse with steering to drift and maneuver through tracks.
- Collisions with obstacles are detected and logged.
- Features include:
  - Smooth acceleration and steering
  - Collision detection (both physical collisions and triggers)
  - Boost mechanics (to be implemented)
  - Drifting mechanics (to be implemented)
  - Interactive environment (road pieces, barriers, etc.)

## Assets

The game includes a variety of 2D assets:
- Multiple car designs (pitstop cars)
- Mechanic characters
- Road pieces and level designs
- UI elements (play button, game title, game over menu)
- Semaphores and traffic signs

## Technical Details

Built with Unity using C#. Key scripts:
- `Driver.cs`: Handles vehicle movement and steering based on keyboard input.
- `Collision.cs`: Logs collision and trigger events for debugging.
- `Editor/RoadBuilderWindow.cs`: Editor tool for constructing road layouts.

## How to Play

1. Open the project in Unity (2021.3 or later recommended).
2. Open the main scene (to be specified).
3. Press Play to start.
4. Use keyboard controls to drive the car.

## Future Features

- Implement boost mechanics (speed bursts)
- Implement drifting visual effects and mechanics
- Add lap timing and race logic
- Expand level variety with different tracks
- Add sound effects and music
- Implement opponent AI cars

Enjoy the ride!