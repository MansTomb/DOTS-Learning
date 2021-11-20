using System;
using System.Collections;
using Components;
using TMPro.EditorUtilities;
using Unity.Collections;
using Unity.Entities;
using Unity.Scenes;
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
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(1f);
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            
            var e = GameObjectConversionUtility.ConvertGameObjectHierarchy(
                nodePrefab,
                GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _assetStore));
            
            var query = _entityManager.CreateEntityQuery(typeof(Node), typeof(Prefab));
            var entities = query.ToEntityArray(Allocator.Temp);
            _entityManager.Instantiate(entities[0]);
            entities.Dispose();
        }

        private void OnDestroy()
        {
            _assetStore.Dispose();
        }
    }
}