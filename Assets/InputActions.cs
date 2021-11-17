// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

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
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d0406f69-4299-4c58-83fc-83892a033289"",
            ""actions"": [
                {
                    ""name"": ""LeftTriggerPressed"",
                    ""type"": ""Value"",
                    ""id"": ""0a46bf3b-36f3-449f-90d9-9fa324b1d970"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTriggerPressed"",
                    ""type"": ""Value"",
                    ""id"": ""78b9fe03-b983-43fe-9a51-62de1686a160"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54e1e183-e0b5-4eac-bc45-8886329d45df"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82a74e5c-104c-480d-b559-3bb959ae29bf"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb2cc2ee-ea59-463f-a74d-d5d18171c0e8"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftTriggerPressed = m_Player.FindAction("LeftTriggerPressed", throwIfNotFound: true);
        m_Player_RightTriggerPressed = m_Player.FindAction("RightTriggerPressed", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftTriggerPressed;
    private readonly InputAction m_Player_RightTriggerPressed;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftTriggerPressed => m_Wrapper.m_Player_LeftTriggerPressed;
        public InputAction @RightTriggerPressed => m_Wrapper.m_Player_RightTriggerPressed;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftTriggerPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTriggerPressed;
                @LeftTriggerPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTriggerPressed;
                @LeftTriggerPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftTriggerPressed;
                @RightTriggerPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTriggerPressed;
                @RightTriggerPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTriggerPressed;
                @RightTriggerPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightTriggerPressed;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftTriggerPressed.started += instance.OnLeftTriggerPressed;
                @LeftTriggerPressed.performed += instance.OnLeftTriggerPressed;
                @LeftTriggerPressed.canceled += instance.OnLeftTriggerPressed;
                @RightTriggerPressed.started += instance.OnRightTriggerPressed;
                @RightTriggerPressed.performed += instance.OnRightTriggerPressed;
                @RightTriggerPressed.canceled += instance.OnRightTriggerPressed;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnLeftTriggerPressed(InputAction.CallbackContext context);
        void OnRightTriggerPressed(InputAction.CallbackContext context);
    }
}
