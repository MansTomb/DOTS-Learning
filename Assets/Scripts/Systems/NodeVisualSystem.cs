using Components;
using Unity.Entities;

namespace Systems
{
    public class NodeVisualSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<Node, NodeSettings>()
                .WithoutBurst()
                .ForEach((NodeVisualData visualData, in NodeSettings settings) =>
                {
                    visualData.visual.TryChangeLevel(settings.level);
                    visualData.visual.TryStartUpgradeParticles(settings.upgradeInProgress);
                }).Run();
        }
    }
}