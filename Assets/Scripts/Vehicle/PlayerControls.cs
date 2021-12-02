// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Vehicle/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""a20b42a9-9f73-448e-8373-9c35a8668c03"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b7baedb-462a-41c9-81a9-85d6afe061e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spacebar"",
                    ""type"": ""Button"",
                    ""id"": ""ea74a363-f0bc-4561-847d-1c927742a844"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d78206fc-73a3-4adc-a3bb-6bdb9259e9f1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""18703e63-9a5e-4ab7-9931-c63871fee7e4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Right click"",
                    ""type"": ""Button"",
                    ""id"": ""1528ced4-4bf1-4b18-90f2-1f36371c8c7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Left click"",
                    ""type"": ""Button"",
                    ""id"": ""df0d39ec-c6b0-49c7-b011-1a1b851959f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""0fa7b3fa-90d4-476f-ba33-d7eed1932392"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""4476ecd3-6661-4b38-96c8-14da2d613f0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""37f7d95a-a786-4dd3-874a-c640351bbd7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a3800666-9ecc-42ee-8a6e-d5dc2dd5c542"",
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
                    ""id"": ""0d69a158-4e33-47de-86fa-90ef44217890"",
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
                    ""id"": ""b5686476-3643-46dd-a189-f9249b4bb937"",
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
                    ""id"": ""4915d0d2-6df7-4d92-a0b6-2215a9410c69"",
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
                    ""id"": ""fc8fa08f-f4f2-4a57-8ed0-1467033c133d"",
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
                    ""id"": ""57ea6a30-4a94-418c-b4e9-70f9aaf635a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spacebar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bea3eba2-158e-4b51-a106-1fafd165fdf3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c115f7c-eae9-402a-9b28-afbbf220ccdf"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2414342-aa93-44b1-847a-4e7452c50d1c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Right click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e77dd77-86fc-4906-a3f3-991fa8534036"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Left click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46e7dcb7-e0f7-47d8-b79d-249d8e5b38e6"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c8bdbbb-a24b-45a8-99d5-53973e287808"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7b587fa-2916-458c-94ec-1056957e0286"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Movement = m_Controls.FindAction("Movement", throwIfNotFound: true);
        m_Controls_Spacebar = m_Controls.FindAction("Spacebar", throwIfNotFound: true);
        m_Controls_MouseHorizontal = m_Controls.FindAction("Mouse Horizontal", throwIfNotFound: true);
        m_Controls_MouseVertical = m_Controls.FindAction("Mouse Vertical", throwIfNotFound: true);
        m_Controls_MouseRightclick = m_Controls.FindAction("Mouse Right click", throwIfNotFound: true);
        m_Controls_MouseLeftclick = m_Controls.FindAction("Mouse Left click", throwIfNotFound: true);
        m_Controls_Tab = m_Controls.FindAction("Tab", throwIfNotFound: true);
        m_Controls_F = m_Controls.FindAction("F", throwIfNotFound: true);
        m_Controls_E = m_Controls.FindAction("E", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Movement;
    private readonly InputAction m_Controls_Spacebar;
    private readonly InputAction m_Controls_MouseHorizontal;
    private readonly InputAction m_Controls_MouseVertical;
    private readonly InputAction m_Controls_MouseRightclick;
    private readonly InputAction m_Controls_MouseLeftclick;
    private readonly InputAction m_Controls_Tab;
    private readonly InputAction m_Controls_F;
    private readonly InputAction m_Controls_E;
    public struct ControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Controls_Movement;
        public InputAction @Spacebar => m_Wrapper.m_Controls_Spacebar;
        public InputAction @MouseHorizontal => m_Wrapper.m_Controls_MouseHorizontal;
        public InputAction @MouseVertical => m_Wrapper.m_Controls_MouseVertical;
        public InputAction @MouseRightclick => m_Wrapper.m_Controls_MouseRightclick;
        public InputAction @MouseLeftclick => m_Wrapper.m_Controls_MouseLeftclick;
        public InputAction @Tab => m_Wrapper.m_Controls_Tab;
        public InputAction @F => m_Wrapper.m_Controls_F;
        public InputAction @E => m_Wrapper.m_Controls_E;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Spacebar.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSpacebar;
                @Spacebar.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSpacebar;
                @Spacebar.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSpacebar;
                @MouseHorizontal.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseHorizontal;
                @MouseHorizontal.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseHorizontal;
                @MouseHorizontal.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseHorizontal;
                @MouseVertical.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseVertical;
                @MouseVertical.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseVertical;
                @MouseVertical.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseVertical;
                @MouseRightclick.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseRightclick;
                @MouseRightclick.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseRightclick;
                @MouseRightclick.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseRightclick;
                @MouseLeftclick.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLeftclick;
                @MouseLeftclick.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLeftclick;
                @MouseLeftclick.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLeftclick;
                @Tab.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTab;
                @Tab.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTab;
                @Tab.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnTab;
                @F.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnF;
                @F.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnF;
                @F.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnF;
                @E.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnE;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Spacebar.started += instance.OnSpacebar;
                @Spacebar.performed += instance.OnSpacebar;
                @Spacebar.canceled += instance.OnSpacebar;
                @MouseHorizontal.started += instance.OnMouseHorizontal;
                @MouseHorizontal.performed += instance.OnMouseHorizontal;
                @MouseHorizontal.canceled += instance.OnMouseHorizontal;
                @MouseVertical.started += instance.OnMouseVertical;
                @MouseVertical.performed += instance.OnMouseVertical;
                @MouseVertical.canceled += instance.OnMouseVertical;
                @MouseRightclick.started += instance.OnMouseRightclick;
                @MouseRightclick.performed += instance.OnMouseRightclick;
                @MouseRightclick.canceled += instance.OnMouseRightclick;
                @MouseLeftclick.started += instance.OnMouseLeftclick;
                @MouseLeftclick.performed += instance.OnMouseLeftclick;
                @MouseLeftclick.canceled += instance.OnMouseLeftclick;
                @Tab.started += instance.OnTab;
                @Tab.performed += instance.OnTab;
                @Tab.canceled += instance.OnTab;
                @F.started += instance.OnF;
                @F.performed += instance.OnF;
                @F.canceled += instance.OnF;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpacebar(InputAction.CallbackContext context);
        void OnMouseHorizontal(InputAction.CallbackContext context);
        void OnMouseVertical(InputAction.CallbackContext context);
        void OnMouseRightclick(InputAction.CallbackContext context);
        void OnMouseLeftclick(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
    }
}
