//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/New script/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""d90c9a18-bb81-4427-b332-17568003e5b6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5aee1e79-cd7d-4c76-b5ba-529e3f48dc42"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4f3dec7a-3af9-44b6-b663-5f650d865dba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""05ea22a9-e57f-4584-95ed-6f5db1779a0c"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9b6ae9b4-8a27-49e7-9781-0c54c2f011cf"",
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
                    ""id"": ""06c390dd-0706-42f3-8140-bb17b1275f2f"",
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
                    ""id"": ""be0ee4b8-d776-418d-9ad8-51ea71d8ac17"",
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
                    ""id"": ""79cd0c8d-38ab-461f-a893-479f2c9d869b"",
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
                    ""id"": ""bd036946-aa85-4731-80df-791917747963"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6532120-3200-4f28-a494-a08f3b57fdd5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""1957f738-e213-44f9-a954-cb5fd846eb3b"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""13655af1-8f0b-4cd8-a688-8b0e1082783a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""b75eaa02-db42-4a13-b96f-afe4b1fb8738"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""6dc2ef01-3cd7-4ab0-87df-155bf1e4446b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CriticalAttack"",
                    ""type"": ""Button"",
                    ""id"": ""727fa979-8b2d-4f2c-ba41-9d5bbe96fc50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""909c2b00-a606-46f2-998f-8ac291579a46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""556fab48-f88d-4c3a-8b87-c2076a6c77a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26ffcc2d-a7a7-42dc-8cc7-c9716c5d8572"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680eb406-10f8-4fb7-8a05-23c1e06a368e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fa78c29-dfc3-49d5-8028-5481098d5db8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a29d4ac4-e751-4efb-97c5-10ea9b4cb21c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34699f0b-7cef-4b85-bf91-e13f543b2a45"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CriticalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f16a80f-168e-434f-af29-48236cd30fca"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CriticalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""447dffb7-62d8-4abb-9191-3924536e6747"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28cd9c38-3127-4027-a863-88d403472786"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6d19a9e-8641-4429-8403-22b6376a74b3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2664ca9b-68c9-4414-b556-5e8ce1721e4e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerQuickSlots"",
            ""id"": ""024b1908-4690-4021-b0a5-47ff6d9d1862"",
            ""actions"": [
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""fe744e35-79c7-4ad7-8124-81b056c71059"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""d5858d30-b678-463f-a77d-f5462c67a990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""94b45ef0-22a0-48d5-a9c4-fcc03a42de11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""487d04ec-e180-4215-9ba2-7fc6cb6b9b31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b2b11cc-9529-4e21-8664-1dd8393a1407"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""047a103f-7364-46be-bd2c-93bdee244fd7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1fd848c-3086-4ecf-a031-10e63450a801"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4236950e-4900-42a3-b44e-b2db5ac0e635"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50bbcc02-8048-47b3-adad-a628d06230db"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d6552d5-5aba-48e5-9320-60651fbb4e81"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3661b45-4db0-48d5-ae02-55203318fe9f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd57f57d-2e8f-43b9-ae0b-d1ecd06ec775"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_RB = m_PlayerActions.FindAction("RB", throwIfNotFound: true);
        m_PlayerActions_RT = m_PlayerActions.FindAction("RT", throwIfNotFound: true);
        m_PlayerActions_CriticalAttack = m_PlayerActions.FindAction("CriticalAttack", throwIfNotFound: true);
        m_PlayerActions_LT = m_PlayerActions.FindAction("LT", throwIfNotFound: true);
        m_PlayerActions_LB = m_PlayerActions.FindAction("LB", throwIfNotFound: true);
        // PlayerQuickSlots
        m_PlayerQuickSlots = asset.FindActionMap("PlayerQuickSlots", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadUp = m_PlayerQuickSlots.FindAction("D-Pad Up", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadDown = m_PlayerQuickSlots.FindAction("D-Pad Down", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadLeft = m_PlayerQuickSlots.FindAction("D-Pad Left", throwIfNotFound: true);
        m_PlayerQuickSlots_DPadRight = m_PlayerQuickSlots.FindAction("D-Pad Right", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_RB;
    private readonly InputAction m_PlayerActions_RT;
    private readonly InputAction m_PlayerActions_CriticalAttack;
    private readonly InputAction m_PlayerActions_LT;
    private readonly InputAction m_PlayerActions_LB;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @RB => m_Wrapper.m_PlayerActions_RB;
        public InputAction @RT => m_Wrapper.m_PlayerActions_RT;
        public InputAction @CriticalAttack => m_Wrapper.m_PlayerActions_CriticalAttack;
        public InputAction @LT => m_Wrapper.m_PlayerActions_LT;
        public InputAction @LB => m_Wrapper.m_PlayerActions_LB;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @RB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @CriticalAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCriticalAttack;
                @LT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @CriticalAttack.started += instance.OnCriticalAttack;
                @CriticalAttack.performed += instance.OnCriticalAttack;
                @CriticalAttack.canceled += instance.OnCriticalAttack;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // PlayerQuickSlots
    private readonly InputActionMap m_PlayerQuickSlots;
    private IPlayerQuickSlotsActions m_PlayerQuickSlotsActionsCallbackInterface;
    private readonly InputAction m_PlayerQuickSlots_DPadUp;
    private readonly InputAction m_PlayerQuickSlots_DPadDown;
    private readonly InputAction m_PlayerQuickSlots_DPadLeft;
    private readonly InputAction m_PlayerQuickSlots_DPadRight;
    public struct PlayerQuickSlotsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerQuickSlotsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DPadUp => m_Wrapper.m_PlayerQuickSlots_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_PlayerQuickSlots_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_PlayerQuickSlots_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_PlayerQuickSlots_DPadRight;
        public InputActionMap Get() { return m_Wrapper.m_PlayerQuickSlots; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerQuickSlotsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerQuickSlotsActions instance)
        {
            if (m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface != null)
            {
                @DPadUp.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface.OnDPadRight;
            }
            m_Wrapper.m_PlayerQuickSlotsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
            }
        }
    }
    public PlayerQuickSlotsActions @PlayerQuickSlots => new PlayerQuickSlotsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnCriticalAttack(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
    }
    public interface IPlayerQuickSlotsActions
    {
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
    }
}
