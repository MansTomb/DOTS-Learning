using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeUpgradeInProgressSystem : SystemBase
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
            var tD = Time.DeltaTime;
            
            Entities
                .WithAll<Node, NodeUpgradeInProgress>()
                .WithBurst()
                .ForEach((Entity entity, int entityInQueryIndex, ref Node node, ref NodeUpgradeInProgress upgrade, ref NodeSettings settings) =>
                {
                    upgrade.progress += tD;
                    if (upgrade.progress < settings.upgradeTime)
                        return;

                    settings.upgradeInProgress = false;
                    settings.level += 1;
                    settings.capacity *= 2;
                    settings.decayRate *= 0.5f;
                    settings.spawnRate /= 2f;
                    settings.upgradeCost *= 2;
                    settings.upgradeTime *= 1.25f;

                    ecb.RemoveComponent<NodeUpgradeInProgress>(entityInQueryIndex, entity);
                })
                .ScheduleParallel();
            
            _buffer.AddJobHandleForProducer(Dependency);
        }
    }
}