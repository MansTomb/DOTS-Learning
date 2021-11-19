using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeDefaultSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var tD = Time.DeltaTime;
            Entities
                .WithAll<Node, NodeDefault>()
                .WithBurst()
                .ForEach((ref Node node, in NodeSettings settings) =>
                {
                    node.timeFromLastSpawn += tD;

                    if (node.timeFromLastSpawn > settings.spawnRate)
                    {
                        node.timeFromLastSpawn = 0f;
                        node.currentUnits++;
                    }
                })
                .ScheduleParallel();
        }
    }
}