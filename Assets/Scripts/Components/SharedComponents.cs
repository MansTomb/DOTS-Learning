using TMPro;
using UI;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct UnderControl : IComponentData { }
    public struct Selected : IComponentData { }
    public struct CanBeSelected : IComponentData { }
    public struct UpdateVisual : IComponentData {}

    public struct PlayerInput : IComponentData
    {
        public bool nodeUpgraded;
        public bool selectionInProgress;
        public bool selectionFinished;
        public float3 doubleTapPosition;
        public float3 mouseStartHoldPosition;
        public float3 mouseCurrentPosition;
    }
    
    public struct DoubleTapped : IComponentData { }
}