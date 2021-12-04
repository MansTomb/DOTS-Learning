using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;
using RaycastHit = Unity.Physics.RaycastHit;

namespace Systems
{
    public class SelectionSystem : SystemBase
    {
        private EntityQuery _q;

        protected override void OnCreate()
        {
            _q = EntityManager.CreateEntityQuery(typeof(CanBeSelected));
        }

        protected override void OnUpdate()
        {
            var input = GetSingleton<PlayerInput>();

            if (input.selectionFinished)
            {
                var camera = Camera.main;
                var selectedEntitites = 0;
                var qArr = _q.ToEntityArray(Allocator.TempJob);

                foreach (var entity in qArr)
                {
                    var t = EntityManager.GetComponentData<Translation>(entity);
                    if (IsWithinSelectionBounds(camera, t.Value, input))
                    {
                        EntityManager.AddComponentData(entity, new Selected());
                        selectedEntitites++;
                    }
                    else
                    {
                        EntityManager.RemoveComponent<Selected>(entity);
                    }
                }

                if (selectedEntitites == 0)
                {
                    var hasHit = TrySelectUnderMouse(camera, input);
                }
                qArr.Dispose();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _q.Dispose();
        }

        bool IsWithinSelectionBounds(Camera camera, Vector3 pos, PlayerInput input)
        {
            var viewportBounds = Utils.GetViewportBounds(camera, input.mouseStartHoldPosition, input.mouseCurrentPosition);
            return viewportBounds.Contains(camera.WorldToViewportPoint(pos));
        }

        private bool TrySelectUnderMouse(Camera camera, PlayerInput input)
        {
            var ray = camera.ScreenPointToRay(input.mouseStartHoldPosition);
            var physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld;
            var collisionWorld = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld.CollisionWorld;

            RaycastHit closestHit;
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
            }, out closestHit);
            
            if (hasHit)
            {
                var e = physicsWorld.Bodies[closestHit.RigidBodyIndex].Entity;
                EntityManager.AddComponent(e, typeof(Selected));
            }

            return hasHit;
        }
    }
}