using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeStateManagerSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _buffer;

        protected override void OnCreate()
        {
            base.OnCreate();
            _buffer = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var ecb = _buffer.CreateCommandBuffer().AsParallelWriter();
            Entities
                .WithAll<Node, UnderControl>()
                .WithNone<Prefab>()
                .WithBurst()
                .ForEach((Entity entity, int entityInQueryIndex, in Node node, in NodeSettings settings) =>
                {
                    ecb.RemoveComponent<NodeDefault>(entityInQueryIndex, entity);
                    ecb.RemoveComponent<NodeOverflow>(entityInQueryIndex, entity);
                    
                    if (node.currentUnits < settings.capacity)
                    {
                        ecb.AddComponent(entityInQueryIndex, entity, new NodeDefault());
                    }
                    else if (node.currentUnits > settings.capacity)
                    {
                        ecb.AddComponent(entityInQueryIndex, entity, new NodeOverflow());
                    }
                })
                .ScheduleParallel();

            _buffer.AddJobHandleForProducer(Dependency);
        }
    }
}