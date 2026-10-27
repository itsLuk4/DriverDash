# Driver Dash

Driver Dash is a 2D top-down car delivery game that showcases driving logic, collision handling, boosts, drifting, and interaction with the environment.

![demo](./Assets/Demo%20GIF's/DriverDash_Smooth.gif)

![demo](./Assets/Demo%20GIF's/DriverDash_ItemPickup.gif)

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
  - Collision detection
  - Boost pickups
  - Drifting mechanics
  - Interactive environment (NPC, Pickup items,...)
  - Package delivery system

## Technical Details

Built with Unity using C#. Key scripts:
- `TopDownCarController.cs`: Has all the driving and steering logic. 
- `Driver.cs`: Has set up Vertical and Horizontal axis when pressing keyboard movement.
- `Package.cs`: Handles OnTrigger situations. Like picking up an item, getting a boost etc.
- `NPC.cs`: Handles animations and transitions (later convo bubble)
etc.

## How to Play

1. Open the project in Unity.
2. Open the main scene.
3. Press Play to start.
4. Use keyboard controls to drive the car "W, S, A, D".

## Future Features

- Implement drifting visual effects and mechanics
- Package delivery mechanic
- Timer for delivery
- Add sound effects and music

Enjoy the ride!
