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

            for (int i = 0; i < 1; i++)
            {
                Instantiate(nodePrefab);
            }
        }

        private void OnDestroy()
        {
            _assetStore.Dispose();
        }
    }
}