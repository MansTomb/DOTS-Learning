using Components;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    public class NodeVisualSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<Node, NodeSettings>()
                .WithNone<Prefab>()
                .WithoutBurst()
                .ForEach((Entity entity, int entityInQueryIndex, NodeVisualData visualData, in NodeSettings settings, in Translation translate) =>
                {
                    visualData.visual.transform.position = translate.Value + visualData.offset;
                    visualData.visual.TryChangeLevel(settings.level);
                    visualData.visual.TrySelect(EntityManager.HasComponent<Selected>(entity));
                    visualData.visual.TryStartUpgradeParticles(settings.upgradeInProgress);
                }).Run();
        }
    }
}