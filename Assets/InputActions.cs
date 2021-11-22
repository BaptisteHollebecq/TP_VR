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
                    ""id"": ""c4b82a08-f152-4809-b9da-adb53d42c4a2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftGripPressed"",
                    ""type"": ""Value"",
                    ""id"": ""76146ab2-17d3-44d0-beb4-8d888c23c8a1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightGripPressed"",
                    ""type"": ""Value"",
                    ""id"": ""01b5a0ec-db40-4317-8d4a-02217919a5ff"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""82a74e5c-104c-480d-b559-3bb959ae29bf"",
                    ""path"": ""<XRController>{LeftHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee45932-7c33-45e3-ae5c-f9e938d55c2e"",
                    ""path"": ""<XRController>{RightHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5224e2f-4502-4e12-9f4a-7f49b7d84ef4"",
                    ""path"": ""<XRController>{LeftHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftGripPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66c758fa-673e-464e-be26-5d8125c6b496"",
                    ""path"": ""<XRController>{RightHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightGripPressed"",
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
        m_Player_LeftGripPressed = m_Player.FindAction("LeftGripPressed", throwIfNotFound: true);
        m_Player_RightGripPressed = m_Player.FindAction("RightGripPressed", throwIfNotFound: true);
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
    private readonly InputAction m_Player_LeftGripPressed;
    private readonly InputAction m_Player_RightGripPressed;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftTriggerPressed => m_Wrapper.m_Player_LeftTriggerPressed;
        public InputAction @RightTriggerPressed => m_Wrapper.m_Player_RightTriggerPressed;
        public InputAction @LeftGripPressed => m_Wrapper.m_Player_LeftGripPressed;
        public InputAction @RightGripPressed => m_Wrapper.m_Player_RightGripPressed;
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
                @LeftGripPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftGripPressed;
                @LeftGripPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftGripPressed;
                @LeftGripPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftGripPressed;
                @RightGripPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightGripPressed;
                @RightGripPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightGripPressed;
                @RightGripPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightGripPressed;
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
                @LeftGripPressed.started += instance.OnLeftGripPressed;
                @LeftGripPressed.performed += instance.OnLeftGripPressed;
                @LeftGripPressed.canceled += instance.OnLeftGripPressed;
                @RightGripPressed.started += instance.OnRightGripPressed;
                @RightGripPressed.performed += instance.OnRightGripPressed;
                @RightGripPressed.canceled += instance.OnRightGripPressed;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnLeftTriggerPressed(InputAction.CallbackContext context);
        void OnRightTriggerPressed(InputAction.CallbackContext context);
        void OnLeftGripPressed(InputAction.CallbackContext context);
        void OnRightGripPressed(InputAction.CallbackContext context);
    }
}
