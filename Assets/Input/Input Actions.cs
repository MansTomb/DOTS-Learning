// GENERATED AUTOMATICALLY FROM 'Assets/Input/Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Actions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""057b9ad1-a498-4a6f-b720-4bfacee22445"",
            ""actions"": [
                {
                    ""name"": ""Upgrade Node"",
                    ""type"": ""Button"",
                    ""id"": ""a3b6d38c-f4d5-42d8-9100-181cf9e497c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""607e4ebc-0251-46f8-a0c4-07223f623d1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e74f0a2-501e-4228-8583-5c0df3c79532"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Upgrade Node"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0375edc0-34fe-44ef-8bbb-04becc913a9f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_UpgradeNode = m_Gameplay.FindAction("Upgrade Node", throwIfNotFound: true);
        m_Gameplay_Selection = m_Gameplay.FindAction("Selection", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_UpgradeNode;
    private readonly InputAction m_Gameplay_Selection;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpgradeNode => m_Wrapper.m_Gameplay_UpgradeNode;
        public InputAction @Selection => m_Wrapper.m_Gameplay_Selection;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @UpgradeNode.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpgradeNode;
                @UpgradeNode.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpgradeNode;
                @UpgradeNode.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUpgradeNode;
                @Selection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelection;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpgradeNode.started += instance.OnUpgradeNode;
                @UpgradeNode.performed += instance.OnUpgradeNode;
                @UpgradeNode.canceled += instance.OnUpgradeNode;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnUpgradeNode(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
    }
}
