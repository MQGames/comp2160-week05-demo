//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Actions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""playerMovement"",
            ""id"": ""9343774d-71a9-405e-984b-e02749e2d25a"",
            ""actions"": [
                {
                    ""name"": ""forward"",
                    ""type"": ""Value"",
                    ""id"": ""3b92070e-a10a-4f0e-9c5f-e8c7d3fda732"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""turn"",
                    ""type"": ""Value"",
                    ""id"": ""7081b3f9-4642-4da3-818c-d22bcab1d312"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""6cd1d42d-f9d6-4111-a993-ba0c52f9f7d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""325551ce-a248-4ad0-a3f7-c242189c0791"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7c9d440b-2cac-4369-acaa-67e228a40101"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0feb1fce-f110-4682-b0bc-ea341ec1da2e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab9e097f-cd8e-47be-9ebc-5c8430e9e80e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb66171b-0eed-49ad-b555-37235773ecda"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerMovement
        m_playerMovement = asset.FindActionMap("playerMovement", throwIfNotFound: true);
        m_playerMovement_forward = m_playerMovement.FindAction("forward", throwIfNotFound: true);
        m_playerMovement_turn = m_playerMovement.FindAction("turn", throwIfNotFound: true);
        m_playerMovement_shoot = m_playerMovement.FindAction("shoot", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // playerMovement
    private readonly InputActionMap m_playerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_playerMovement_forward;
    private readonly InputAction m_playerMovement_turn;
    private readonly InputAction m_playerMovement_shoot;
    public struct PlayerMovementActions
    {
        private @Actions m_Wrapper;
        public PlayerMovementActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @forward => m_Wrapper.m_playerMovement_forward;
        public InputAction @turn => m_Wrapper.m_playerMovement_turn;
        public InputAction @shoot => m_Wrapper.m_playerMovement_shoot;
        public InputActionMap Get() { return m_Wrapper.m_playerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @forward.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnForward;
                @forward.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnForward;
                @forward.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnForward;
                @turn.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurn;
                @turn.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurn;
                @turn.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurn;
                @shoot.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @forward.started += instance.OnForward;
                @forward.performed += instance.OnForward;
                @forward.canceled += instance.OnForward;
                @turn.started += instance.OnTurn;
                @turn.performed += instance.OnTurn;
                @turn.canceled += instance.OnTurn;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
            }
        }
    }
    public PlayerMovementActions @playerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
