// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""cb4b4782-ee67-4771-ac14-201174fe628f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9f22feb5-73a7-47e2-9ce6-f8754a6111fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Head"",
                    ""type"": ""Button"",
                    ""id"": ""473e24cb-4e51-434e-be6f-7d7db6184b8c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Body"",
                    ""type"": ""Button"",
                    ""id"": ""5a46fade-e908-477d-a665-f44c6c966dcc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Arms"",
                    ""type"": ""Button"",
                    ""id"": ""60ea519c-1936-446b-8612-8001a060097c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Legs"",
                    ""type"": ""Button"",
                    ""id"": ""acdf29cf-669e-4209-8c82-fec83ab4b8e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9aa11335-589d-4835-9f6c-21ccc6ec940a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""a27b121e-53f1-45f7-89b6-fe4fee7e8a2b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0151210-5851-4850-b6fc-412f56cecb59"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""05bc4bf0-4493-400f-924b-82f9173a6c8b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dd72d654-5567-4f6d-a9e2-7e89f71c3cc0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10416d02-b9cf-4ca6-8686-ff0492936003"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0fc73ffd-8021-42e6-983b-15df3ecd82bf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Body"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0d1f2c0-217a-4046-ad0b-65a3971ab89c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Body"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e155f5bd-3b2f-4d78-b7c4-4cc17135806f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Legs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d72d5cb5-0939-4853-9349-509685730302"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Legs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd06d4fb-3062-434d-b144-cfe037650923"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arms"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fd11bd3-1d9c-4ebf-acd7-38d07c89f108"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arms"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c251362f-1856-494c-8908-96504c59b8b1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Head = m_Gameplay.FindAction("Head", throwIfNotFound: true);
        m_Gameplay_Body = m_Gameplay.FindAction("Body", throwIfNotFound: true);
        m_Gameplay_Arms = m_Gameplay.FindAction("Arms", throwIfNotFound: true);
        m_Gameplay_Legs = m_Gameplay.FindAction("Legs", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Head;
    private readonly InputAction m_Gameplay_Body;
    private readonly InputAction m_Gameplay_Arms;
    private readonly InputAction m_Gameplay_Legs;
    public struct GameplayActions
    {
        private @PlayerInput m_Wrapper;
        public GameplayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Head => m_Wrapper.m_Gameplay_Head;
        public InputAction @Body => m_Wrapper.m_Gameplay_Body;
        public InputAction @Arms => m_Wrapper.m_Gameplay_Arms;
        public InputAction @Legs => m_Wrapper.m_Gameplay_Legs;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Head.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHead;
                @Head.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHead;
                @Head.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHead;
                @Body.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBody;
                @Body.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBody;
                @Body.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBody;
                @Arms.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArms;
                @Arms.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArms;
                @Arms.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArms;
                @Legs.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegs;
                @Legs.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegs;
                @Legs.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegs;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Head.started += instance.OnHead;
                @Head.performed += instance.OnHead;
                @Head.canceled += instance.OnHead;
                @Body.started += instance.OnBody;
                @Body.performed += instance.OnBody;
                @Body.canceled += instance.OnBody;
                @Arms.started += instance.OnArms;
                @Arms.performed += instance.OnArms;
                @Arms.canceled += instance.OnArms;
                @Legs.started += instance.OnLegs;
                @Legs.performed += instance.OnLegs;
                @Legs.canceled += instance.OnLegs;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnHead(InputAction.CallbackContext context);
        void OnBody(InputAction.CallbackContext context);
        void OnArms(InputAction.CallbackContext context);
        void OnLegs(InputAction.CallbackContext context);
    }
}
