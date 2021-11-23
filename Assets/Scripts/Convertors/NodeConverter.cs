using Components;
using TMPro;
using UI;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

[DisallowMultipleComponent]
public class NodeConverter : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private Vector3 offset;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new UnderControl());
        dstManager.AddComponentData(entity, new Node());
        dstManager.AddComponentData(entity, new NodeSettings()
        {
            level = 1,
            maxLevel = 2,
            capacity = 10,
            decayRate = 1,
            spawnRate = 1,
            upgradeCost = 5,
            upgradeTime = 2
        });
        dstManager.AddComponentData(entity, new NodeUIData()
        {
            label = Pool<NodeUI>.Instance.Get(),
            offset = offset
        });
        dstManager.AddComponentData(entity, new NodeVisualData()
        {
            visual = Pool<NodeVisual>.Instance.Get(),
            offset = new float3(0, 0, 0)
        });
    }
}
