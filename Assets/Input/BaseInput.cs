//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/BaseInput.inputactions
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

public partial class @BaseInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BaseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BaseInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""49645ce3-aacf-47b2-993a-ef927ed49a8b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2458e86b-ab68-4b47-b408-1bf9ef85a943"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Forward Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a99e27cf-e493-4134-8a9d-e8cdd36f3818"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Side Movement"",
                    ""type"": ""Value"",
                    ""id"": ""28e27d83-1382-491e-b77e-feec02552b8e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""0d381103-b8d7-4168-a5ad-9d609fbe57bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot Primary Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""df7e4bb4-09ed-4751-8675-16090b2926e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot Secondary Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""fa391f16-1eb0-4e24-9bb8-b164c6074039"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""41026089-2a7f-49c5-82bc-a1b10f5a2857"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard Stick"",
                    ""id"": ""d3d916df-e802-4656-ae22-4e3d933cd396"",
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
                    ""id"": ""cb075134-1462-425a-8aaf-52a203ed0bc4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4ee6d3b0-cb9e-4919-8e35-f8df8e60e075"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0e307ecf-c35f-418b-bcf1-a6871c562414"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e3e79c4f-7b00-4823-9a19-894f470cd604"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b26ea486-0826-4f25-b149-d72343566b78"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Forward Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard Axis"",
                    ""id"": ""584c813e-0cf5-4986-9a4b-7ae0512589ad"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6e2bfd70-ff99-47b9-ac8f-1d821dedcc2c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Forward Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f81dad0a-f135-4b0a-889d-13e05bda6690"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Forward Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""75fc4d64-780f-4c08-aa10-329550e8a8f7"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Side Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard Axis"",
                    ""id"": ""468cd593-e302-40a0-89ea-eca1713c5904"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Side Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4c9403e6-bb26-4016-a4f8-db316c4243da"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Side Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""da89185b-8c27-4b9b-a2d5-4f958c162344"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Side Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""987fdaea-7343-44fb-af69-106ceb919cc9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7135f146-54a0-4e85-a61d-199570428761"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b449ba03-b3b3-4972-b8da-ed45284b15aa"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot Primary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35a85fa4-f72b-434d-adce-ae73fe6959a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Shoot Primary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c780b9ec-fb74-4329-a9f7-a2212c43c504"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot Secondary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cba4085-bad9-49da-80e8-963aba702f36"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse+KB"",
                    ""action"": ""Shoot Secondary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse+KB"",
            ""bindingGroup"": ""Mouse+KB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_ForwardMovement = m_Gameplay.FindAction("Forward Movement", throwIfNotFound: true);
        m_Gameplay_SideMovement = m_Gameplay.FindAction("Side Movement", throwIfNotFound: true);
        m_Gameplay_Boost = m_Gameplay.FindAction("Boost", throwIfNotFound: true);
        m_Gameplay_ShootPrimaryWeapon = m_Gameplay.FindAction("Shoot Primary Weapon", throwIfNotFound: true);
        m_Gameplay_ShootSecondaryWeapon = m_Gameplay.FindAction("Shoot Secondary Weapon", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_ForwardMovement;
    private readonly InputAction m_Gameplay_SideMovement;
    private readonly InputAction m_Gameplay_Boost;
    private readonly InputAction m_Gameplay_ShootPrimaryWeapon;
    private readonly InputAction m_Gameplay_ShootSecondaryWeapon;
    public struct GameplayActions
    {
        private @BaseInput m_Wrapper;
        public GameplayActions(@BaseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @ForwardMovement => m_Wrapper.m_Gameplay_ForwardMovement;
        public InputAction @SideMovement => m_Wrapper.m_Gameplay_SideMovement;
        public InputAction @Boost => m_Wrapper.m_Gameplay_Boost;
        public InputAction @ShootPrimaryWeapon => m_Wrapper.m_Gameplay_ShootPrimaryWeapon;
        public InputAction @ShootSecondaryWeapon => m_Wrapper.m_Gameplay_ShootSecondaryWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @ForwardMovement.started += instance.OnForwardMovement;
            @ForwardMovement.performed += instance.OnForwardMovement;
            @ForwardMovement.canceled += instance.OnForwardMovement;
            @SideMovement.started += instance.OnSideMovement;
            @SideMovement.performed += instance.OnSideMovement;
            @SideMovement.canceled += instance.OnSideMovement;
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
            @ShootPrimaryWeapon.started += instance.OnShootPrimaryWeapon;
            @ShootPrimaryWeapon.performed += instance.OnShootPrimaryWeapon;
            @ShootPrimaryWeapon.canceled += instance.OnShootPrimaryWeapon;
            @ShootSecondaryWeapon.started += instance.OnShootSecondaryWeapon;
            @ShootSecondaryWeapon.performed += instance.OnShootSecondaryWeapon;
            @ShootSecondaryWeapon.canceled += instance.OnShootSecondaryWeapon;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @ForwardMovement.started -= instance.OnForwardMovement;
            @ForwardMovement.performed -= instance.OnForwardMovement;
            @ForwardMovement.canceled -= instance.OnForwardMovement;
            @SideMovement.started -= instance.OnSideMovement;
            @SideMovement.performed -= instance.OnSideMovement;
            @SideMovement.canceled -= instance.OnSideMovement;
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
            @ShootPrimaryWeapon.started -= instance.OnShootPrimaryWeapon;
            @ShootPrimaryWeapon.performed -= instance.OnShootPrimaryWeapon;
            @ShootPrimaryWeapon.canceled -= instance.OnShootPrimaryWeapon;
            @ShootSecondaryWeapon.started -= instance.OnShootSecondaryWeapon;
            @ShootSecondaryWeapon.performed -= instance.OnShootSecondaryWeapon;
            @ShootSecondaryWeapon.canceled -= instance.OnShootSecondaryWeapon;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_MouseKBSchemeIndex = -1;
    public InputControlScheme MouseKBScheme
    {
        get
        {
            if (m_MouseKBSchemeIndex == -1) m_MouseKBSchemeIndex = asset.FindControlSchemeIndex("Mouse+KB");
            return asset.controlSchemes[m_MouseKBSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnForwardMovement(InputAction.CallbackContext context);
        void OnSideMovement(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnShootPrimaryWeapon(InputAction.CallbackContext context);
        void OnShootSecondaryWeapon(InputAction.CallbackContext context);
    }
}