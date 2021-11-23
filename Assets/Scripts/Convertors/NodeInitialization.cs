using System;
using Unity.Entities;
using UnityEngine;

namespace Convertors
{
    public class NodeInitialization : MonoBehaviour
    {
        [SerializeField] private GameObject nodePrefab;

        private BlobAssetStore _assetStore;
        private EntityManager _entityManager;

        private void Awake()
        {
            _assetStore = new BlobAssetStore();

            var go = Instantiate(nodePrefab);
            go.transform.position = new Vector3(-1 * 5, 0, 0);
            
            var go1 = Instantiate(nodePrefab);
            go1.transform.position = new Vector3(1 * 5, 0, 0);
        }

        private void OnDestroy()
        {
            _assetStore.Dispose();
        }
    }
}