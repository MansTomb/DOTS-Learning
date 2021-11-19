using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using PlayerInput = Components.PlayerInput;

namespace Systems
{
    [AlwaysUpdateSystem]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class InputGatheringSystem : SystemBase, InputActions.IGameplayActions
    {
        private InputActions _inputActions;
        private EntityQuery _inputQuery;

        private bool _nodeUpgraded;

        protected override void OnStartRunning() => _inputActions.Enable();
        protected override void OnStopRunning() => _inputActions.Disable();

        protected override void OnCreate()
        {
            _inputActions = new InputActions();
            _inputActions.Gameplay.SetCallbacks(this);
            
            _inputQuery = GetEntityQuery(typeof(PlayerInput));
        }

        protected override void OnUpdate()
        {
            if (_inputQuery.CalculateEntityCount() == 0)
                EntityManager.CreateEntity(typeof(PlayerInput));

            var pos = Mouse.current.position.ReadValue();
            _inputQuery.SetSingleton(new PlayerInput()
            {
                nodeUpgraded = _nodeUpgraded,
                nodeUpgradedPosition = new float3(pos.x, pos.y, 0)
            });

            _nodeUpgraded = false;
        }

        public void OnUpgradeNode(InputAction.CallbackContext context) => _nodeUpgraded = context.performed;
    }
}