using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
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
        private bool _selectionInProgress;
        private bool _selectionFinished;
        private float3 _mouseStartHold;

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
                selectionInProgress = _selectionInProgress,
                selectionFinished = _selectionFinished,
                doubleTapPosition = new float3(pos.x, pos.y, 0),
                mouseStartHoldPosition = _mouseStartHold,
                mouseCurrentPosition = Input.mousePosition
            });

            _nodeUpgraded = false;
            _selectionFinished = false;
        }

        public void OnUpgradeNode(InputAction.CallbackContext context)
        {
            _nodeUpgraded = context.performed;
        }

        public void OnSelection(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log($"Touched UI");
                    return;
                }
                
                _mouseStartHold = Input.mousePosition;
                _selectionInProgress = true;
                Debug.Log($"Start selection");
            }

            if (_selectionInProgress && context.canceled)
            {
                _selectionInProgress = false;
                _selectionFinished = true;
                Debug.Log($"Finish selection");
            }
        }
    }
}