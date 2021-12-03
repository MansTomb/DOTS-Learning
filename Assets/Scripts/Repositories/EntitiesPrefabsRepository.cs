using Unity.Entities;
using UnityEngine;

namespace Repositories 
{
    public class EntitiesPrefabsRepository : MonoBehaviour
    {
        [SerializeField] private GameObject nodePrefab;

        private BlobAssetStore _assetStore;
        
        public static Entity NodeEntityPrefab { get; private set; }

        private void Awake()
        {
            _assetStore = new BlobAssetStore();
        }

        private void Start()
        {
            NodeEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(nodePrefab, GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _assetStore));
        }

        private void OnDestroy()
        {
            _assetStore.Dispose();
        }
    }
}