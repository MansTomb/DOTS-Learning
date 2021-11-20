using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;
using RaycastHit = Unity.Physics.RaycastHit;

namespace Systems
{
    public class DoubleTapSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var input = GetSingleton<PlayerInput>();
            if (!input.nodeUpgraded)
                return;

            var physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld;
            var collisionWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld.CollisionWorld;

            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(input.nodeUpgradedPosition);
            
            var hasHit = collisionWorld.CastRay(new RaycastInput()
            {
                Start = ray.origin,
                End = ray.direction * 1000f,
                Filter = new CollisionFilter()
                {
                    CollidesWith = ~0u,
                    BelongsTo = ~0u,
                    GroupIndex = 0,
                }
            }, out RaycastHit closestHit);

            if (hasHit)
            {
                var e = physicsWorld.Bodies[closestHit.RigidBodyIndex].Entity;
                EntityManager.AddComponent(e, typeof(DoubleTapped));
            }
        }
    }
}