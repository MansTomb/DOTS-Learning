using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct UnderControl : IComponentData { }

    public struct PlayerInput : IComponentData
    {
        public bool nodeUpgraded;
        public float3 nodeUpgradedPosition;
    }
    
    public struct DoubleTapped : IComponentData { }
    
    public struct Node : IComponentData
    {
        public int currentUnits;

        public float timeFromLastSpawn;
        public float timeFromLastDecay;
    }

    public struct NodeUpgradeInProgress : IComponentData
    {
        public float progress;
    }

    public struct NodeSettings : IComponentData
    {
        public int capacity;
        public float spawnRate;
        public float decayRate;

        public int upgradeCost;
        public float upgradeTime;
    }
    public struct NodeOverflow : IComponentData {}
    public struct NodeDefault : IComponentData {}
}