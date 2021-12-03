using Components;
using UI;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisallowMultipleComponent]
public class NodeConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private Vector3 offset;
    
    private static Vector3 DefaultOffset;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        DefaultOffset = offset;

        dstManager.AddComponentData(entity, new UnderControl());
        dstManager.AddComponentData(entity, new Node());
        dstManager.AddComponentData(entity, DefaultSettings());
        dstManager.AddComponentData(entity, new NodeUIData()
        {
            label = null,
            offset = offset
        });
        dstManager.AddComponentData(entity, new NodeVisualData()
        {
            visual = null,
            offset = new float3(0, 0, 0)
        });
    }

    public static void PopulateEntity(EntityCommandBuffer ecb, Entity e, SpawnNode spawn)
    {
        ecb.SetComponent(e, new Translation() {Value = spawn.location});
        ecb.SetComponent(e, new NodeUIData()
        {
            label = Pool<NodeUI>.Instance.Get(),
            offset = DefaultUIOffset(),
        });
        ecb.SetComponent(e, new NodeVisualData()
        {
            visual = Pool<NodeVisual>.Instance.Get(),
            offset = new float3(0, 0, 0)
        });
    }

    public static NodeSettings DefaultSettings()
    {
        return new NodeSettings()
        {
            level = 1,
            maxLevel = 2,
            capacity = 10,
            decayRate = 1,
            spawnRate = 1,
            upgradeCost = 5,
            upgradeTime = 2
        };
    }

    public static float3 DefaultUIOffset()
    {
        return DefaultOffset;
    }
}
