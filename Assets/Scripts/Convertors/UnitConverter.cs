using Components;
using Pools;
using UI;
using Unity.Entities;
using UnityEngine;

namespace Convertors
{
    public class UnitConverter : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new Unit()
            {
                damage = 1,
                sender = Entity.Null,
                target = Entity.Null
            });
            dstManager.AddComponentData(entity, new UnitVisualData()
            {
                visual = Pool<UnitVisual>.Instance.Get()
            });
        }
    }
}