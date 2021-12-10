# Design patterns the game
## Observer pattern
At Assets/Scripts/Object Pool/Exp.cs, OnExpPickUp invokes every time an exp gets picked up. The ExpSpawner.cs listens to that action, returns the picked up exp to the exp pool and spawns a new one from the pool.

## Generic object pool
At Assets/Scripts/Object Pool/GenericObjectPool.cs 
Both BulletPool and ExpOrbPool derives from this abstract class, 

## Generic singleton for object pools
At Assets/Scripts/Object Pool/GenericObjectPool.cs 
Each object pool only needs one instance and that's why they have a singleton. This is a handy way of having easy access to each pool, for example BulletPool.Instance

## Command Pattern

## State Pattern
