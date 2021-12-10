# Design patterns the game

## Observer Pattern
At Assets/Scripts/Object Pool/Exp.cs, OnExpPickUp invokes every time an exp gets picked up. The ExpSpawner.cs listens to that action, returns the picked up exp to the exp pool and spawns a new one from the pool.

## Generic Object Pool
At Assets/Scripts/Object Pool/GenericObjectPool.cs 
Both BulletPool and ExpOrbPool derives from this abstract class, helps creating new object pools. The Get method returns a disabled object, either by instantiating one or getting one from the queue. ReturnToPool returns the object to the pool (queue) and disables the object. 

## Generic Singleton For Object Pools
At Assets/Scripts/Object Pool/GenericObjectPool.cs 
Each object pool only needs one instance and that's why they have a singleton. This is a handy way of having easy access to each pool, for example BulletPool.Instance

## Dependency Injection
At Assets/Scripts/Vehicle/CarController.cs
Most places in my code usually uses some kind of dependency injection. An example is the CarController that depends on the Steering and Motor class, I use the SerializeField attribute to inject the dependencies. 
## Component Pattern

At Assets/Scripts/Vehicle/CarController.cs
Instead of having a single car class I divided it into smaller components, Steering, Controller, Motor, Weapon. All of those components combined creates the "Car"



