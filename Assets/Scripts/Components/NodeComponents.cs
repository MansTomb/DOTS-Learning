using UI;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct SpawnNode : IComponentData
    {
        public float3 location;
    }
    
    public struct Node : IComponentData
    {
        public int currentUnits;

        public float timeFromLastSpawn;
        public float timeFromLastDecay;
    }

    public class NodeUIData : IComponentData
    {
        public NodeUI label;

        public float lastUpdate;
        public float3 offset;
    }

    public class NodeVisualData : IComponentData
    {
        public NodeVisual visual;
        public float3 offset;
    }

    public struct NodeUpgradeInProgress : IComponentData
    {
        public float progress;
    }

    public struct NodeSettings : IComponentData
    {
        public int level;
        public int maxLevel;

        public int capacity;
        public float spawnRate;
        public float decayRate;

        public int upgradeCost;
        public float upgradeTime;

        public bool upgradeInProgress;
    }

    public struct NodeOverflow : IComponentData
    {
    }

    public struct NodeDefault : IComponentData
    {
    }
}