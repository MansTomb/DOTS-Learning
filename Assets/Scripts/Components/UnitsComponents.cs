using UI;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct Unit : IComponentData
    {
        public int damage;

        public Entity sender;
        public Entity target;
    }

    public struct UnitMoving : IComponentData
    {
        
    }

    public struct UnitFinishedMoving : IComponentData
    {
        public Entity finalNode;
    }

    public class UnitVisualData : IComponentData
    {
        public UnitVisual visual;
    }
}