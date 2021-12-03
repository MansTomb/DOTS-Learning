using Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class NodeCreation : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;

    private void Awake()
    {
        x = 0f;
        y = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x -= 1;
        }
            
        if (Input.GetKeyDown(KeyCode.F))
        {
            var e = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntity(typeof(SpawnNode));
            World.DefaultGameObjectInjectionWorld.EntityManager.SetComponentData(e, new SpawnNode() { location = new float3(x, y, 0)});;
        }
    }
}