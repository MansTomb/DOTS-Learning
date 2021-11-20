using Components;
using TMPro;
using UI;
using Unity.Entities;
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
            capacity = 10,
            decayRate = 1,
            spawnRate = 1,
            upgradeCost = 5,
            upgradeTime = 2
        });
        dstManager.AddComponentData(entity, new NodeUIData()
        {
            label = NodeUIPool.Instance.Get(),
            offset = offset
        });
    }
}
