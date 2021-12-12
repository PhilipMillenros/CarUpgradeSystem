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
At Assets/Scripts/Vehicle/CarMotor.cs
CarMotor has a IMovementInput reference, CarMotor can read the Horizontal/Vertical value from any script that derives from an IMovementInput interface. This makes it easier when adding A.I's and networking + other inputs. The dependencies gets injected in the SetMotor method by the PlayerClient.cs class (Assets/Scripts/Player/PlayerClient.cs). 
## Component Pattern

At Assets/Scripts/Vehicle/CarController.cs
Instead of having a single car class I divided it into smaller components, Steering, Controller, Motor, Weapon. All of those components combined creates the "Car"



