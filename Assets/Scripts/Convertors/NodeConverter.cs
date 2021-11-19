using Components;
using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class NodeConverter : MonoBehaviour, IConvertGameObjectToEntity
{
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
    }
}
