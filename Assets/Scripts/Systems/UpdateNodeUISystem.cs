using Components;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class UpdateNodeUISystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var tD = Time.DeltaTime;
            
            Entities
                .WithAll<Node, NodeSettings>()
                .WithoutBurst()
                .ForEach((NodeUIData uiData, in Node data, in NodeSettings settings, in Translation translation) =>
                {
                    uiData.lastUpdate += tD;

                    if (uiData.lastUpdate < settings.spawnRate)
                    {
                        return;   
                    }
                    if (uiData.lastUpdate < settings.decayRate)
                    {
                        return;
                    }

                    uiData.lastUpdate = 0f;

                    uiData.label.transform.position = translation.Value + uiData.offset;
                    uiData.label.text.text = "Units: " + data.currentUnits;
                }).Run();
        }
    }
}