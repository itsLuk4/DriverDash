# Driver Dash

Driver Dash is a 2D top-down racing game that showcases driving logic, collision handling, boosts, drifting, and interaction with the environment.

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
  - Implemented boost mechanic (speed bursts)

## Technical Details

Built with Unity using C#. Key scripts:
- `TopDownCarController.cs`: Has all the driving and steering logic. 
- `Driver.cs`: Has set up Vertical and Horizontal axis when pressing keyboard movement.
- `Delivery.cs`: Handles OnTrigger situations. Like picking up an item, getting a boost etc.

## How to Play

1. Open the project in Unity.
2. Open the main scene.
3. Press Play to start.
4. Use keyboard controls to drive the car "W, S, A, D".

## Future Features

- Implement drifting visual effects and mechanics
- Add lap timing and race logic
- Expand level variety with different tracks
- Add sound effects and music
- Implement opponent AI cars

Enjoy the ride!
