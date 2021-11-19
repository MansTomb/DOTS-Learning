using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeOverflowSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var tD = Time.DeltaTime;
            Entities
                .WithAll<Node, NodeOverflow>()
                .WithBurst()
                .ForEach((ref Node node, in NodeSettings settings) =>
                {
                    node.timeFromLastDecay += tD;

                    if (node.currentUnits == 0)
                        return;

                    if (node.timeFromLastDecay > settings.decayRate)
                    {
                        node.timeFromLastDecay = 0f;
                        node.currentUnits--;
                    }
                })
                .ScheduleParallel();
        }
    }
}