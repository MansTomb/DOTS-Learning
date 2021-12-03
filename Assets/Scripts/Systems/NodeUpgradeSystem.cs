using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeUpgradeSystem : SystemBase
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
                .WithAll<Node, DoubleTapped>()
                .WithNone<NodeUpgradeInProgress, Prefab>()
                .WithBurst()
                .ForEach((Entity entity, int entityInQueryIndex, ref Node node, ref NodeSettings settings) =>
                {
                    if (settings.level == settings.maxLevel)
                    {
                        ecb.RemoveComponent<DoubleTapped>(entityInQueryIndex, entity);
                        return;
                    }

                    if (node.currentUnits > settings.upgradeCost) 
                    {
                        node.currentUnits -= settings.upgradeCost;

                        settings.upgradeInProgress = true;
                        ecb.RemoveComponent<DoubleTapped>(entityInQueryIndex, entity);
                        ecb.AddComponent(entityInQueryIndex, entity, new NodeUpgradeInProgress() {progress = 0f});
                    }
                    else
                    {
                        ecb.RemoveComponent<DoubleTapped>(entityInQueryIndex, entity);
                    }
                })
                .ScheduleParallel();
            
            _buffer.AddJobHandleForProducer(Dependency);
        }
    }
}