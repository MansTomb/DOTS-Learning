using TMPro;
using UI;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct UnderControl : IComponentData { }
    public struct UpdateVisual : IComponentData {}

    public struct PlayerInput : IComponentData
    {
        public bool nodeUpgraded;
        public float3 nodeUpgradedPosition;
    }
    
    public struct DoubleTapped : IComponentData { }
}