using Components;
using Repositories;
using Unity.Entities;

namespace Systems
{
    public class NodeSpawnSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _buffer;

        protected override void OnCreate()
        {
            base.OnCreate();
            
            _buffer = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var ecb = _buffer.CreateCommandBuffer();

            Entities
                .WithAll<SpawnNode>()
                .WithNone<Prefab>()
                .WithoutBurst()
                .ForEach((Entity entity, int entityInQueryIndex, in SpawnNode spawn) =>
                {
                    var e = ecb.Instantiate(EntitiesPrefabsRepository.NodeEntityPrefab);
                    NodeConverter.PopulateEntity(ecb, e, spawn);
                    ecb.DestroyEntity(entity);
                })
                .Run();
        }
    }
}