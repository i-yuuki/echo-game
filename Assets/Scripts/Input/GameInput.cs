// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Echo
{
    public class @GameInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c5a5a01e-ee35-4cf9-b502-b497b0f4a8e0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4d029d10-7c19-40eb-89cb-01939fc1f0a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e6643159-6810-4bee-b636-2561863e1ef4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reflect"",
                    ""type"": ""Button"",
                    ""id"": ""273f4e5d-73d6-4043-9452-a259476efdd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slowmo"",
                    ""type"": ""Button"",
                    ""id"": ""0ba21313-a1b1-4c83-bea1-6055babd1340"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""87fb570c-57c4-4be8-b288-5a46d0aab83d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e3db0efc-0371-41c2-84b7-12b16bdf4aa2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5951e254-8017-444d-a2a0-49001fa8ef73"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8e6c44c8-ff5a-44df-b3e3-8cdc032380ee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""95d00872-a508-4e4a-8cb7-1ddfb9c31a39"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c000a495-efed-48c9-9916-55220bae9584"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a7c9e0b-e071-4723-8f3e-7f659b8f8c19"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3495e00-65ce-43d0-8309-72f457c001f3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""705e9125-660f-4ca2-9a6f-d46938dd7278"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reflect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f10c0ef-0c41-4850-9ff4-110936677ea3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reflect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e336eec3-785a-443d-96d4-371c889d539c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Slowmo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d370d08f-6932-4a37-b8fe-6caa0a5b8abf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slowmo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""1f2a9c31-11df-4dea-a734-c5ddcfe469e3"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""d455a759-53ec-4e7e-9ed7-2c05126fafd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""273de8ce-16cc-4224-ae65-5a8fdf4ace07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""e90e1ffe-b979-4b32-80a6-789cbea2de69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fe5a9a3b-b111-4776-8990-69484ab336d8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5238e1fb-bb73-47fc-b3e5-603f88016dee"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6a31fc7-9aa2-4819-8fb8-1be0e70a4b8c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee78b6a-a3b6-427b-9f73-896773eada4a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dc68a37-8738-4810-a03a-b49311e8de50"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;Gamepad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
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
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
            m_Gameplay_Reflect = m_Gameplay.FindAction("Reflect", throwIfNotFound: true);
            m_Gameplay_Slowmo = m_Gameplay.FindAction("Slowmo", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Left = m_Menu.FindAction("Left", throwIfNotFound: true);
            m_Menu_Right = m_Menu.FindAction("Right", throwIfNotFound: true);
            m_Menu_Confirm = m_Menu.FindAction("Confirm", throwIfNotFound: true);
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
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Interact;
        private readonly InputAction m_Gameplay_Reflect;
        private readonly InputAction m_Gameplay_Slowmo;
        public struct GameplayActions
        {
            private @GameInput m_Wrapper;
            public GameplayActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
            public InputAction @Reflect => m_Wrapper.m_Gameplay_Reflect;
            public InputAction @Slowmo => m_Wrapper.m_Gameplay_Slowmo;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Reflect.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReflect;
                    @Reflect.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReflect;
                    @Reflect.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReflect;
                    @Slowmo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowmo;
                    @Slowmo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowmo;
                    @Slowmo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSlowmo;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Reflect.started += instance.OnReflect;
                    @Reflect.performed += instance.OnReflect;
                    @Reflect.canceled += instance.OnReflect;
                    @Slowmo.started += instance.OnSlowmo;
                    @Slowmo.performed += instance.OnSlowmo;
                    @Slowmo.canceled += instance.OnSlowmo;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Left;
        private readonly InputAction m_Menu_Right;
        private readonly InputAction m_Menu_Confirm;
        public struct MenuActions
        {
            private @GameInput m_Wrapper;
            public MenuActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Left => m_Wrapper.m_Menu_Left;
            public InputAction @Right => m_Wrapper.m_Menu_Right;
            public InputAction @Confirm => m_Wrapper.m_Menu_Confirm;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Left.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Confirm.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                    @Confirm.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                    @Confirm.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Confirm.started += instance.OnConfirm;
                    @Confirm.performed += instance.OnConfirm;
                    @Confirm.canceled += instance.OnConfirm;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
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
            void OnMove(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnReflect(InputAction.CallbackContext context);
            void OnSlowmo(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnConfirm(InputAction.CallbackContext context);
        }
    }
}
