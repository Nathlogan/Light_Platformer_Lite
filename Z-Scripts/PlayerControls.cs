// GENERATED AUTOMATICALLY FROM 'Assets/Z-Scripts/PlayerControls.inputactions'

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
            ""name"": ""Right Controls"",
            ""id"": ""1e792854-98b3-44c2-a6c2-254184f1259f"",
            ""actions"": [
                {
                    ""name"": ""Toggle Laser"",
                    ""type"": ""Button"",
                    ""id"": ""c658e59c-5556-4f8a-91e2-bb8258bb68c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""72ce4146-1122-4b73-b62d-2095b6e0cf77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Color"",
                    ""type"": ""Button"",
                    ""id"": ""6f069600-a39d-45d3-a0a2-6a6fca91da71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Platform"",
                    ""type"": ""Button"",
                    ""id"": ""29d42915-0333-46cc-9573-b122bb84bc8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn Crystal"",
                    ""type"": ""Button"",
                    ""id"": ""2470d4ec-a1a6-4d59-af6e-7577d539f73f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leap"",
                    ""type"": ""Button"",
                    ""id"": ""2a0f05a7-c817-43b4-a1f0-efc71ff61e5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""694bc782-ed8c-4ab3-89a0-addb4eb350f7"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Toggle Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""748367d3-16cb-4669-b799-19441fd97936"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Toggle Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b47da69c-35a7-420c-bf01-c2c871b9206d"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Toggle Color"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fb0d25c-c74c-429e-a8c4-54c38a3ae391"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Move Platform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""9d45f261-9c4d-4a07-bb3e-12b4f3239558"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Crystal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f1e20a2e-b64d-4ca7-9a63-1e2e4586fd76"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Spawn Crystal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f5158888-9178-42b5-92d5-ad08514093d1"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Spawn Crystal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b2af361-8b47-4145-8e53-182aa0519407"",
                    ""path"": ""<XRController>{RightHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Leap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Left Controls"",
            ""id"": ""4904ecc3-ca24-42a1-995c-71e1766e0243"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bb152657-c27c-4714-8794-0ad0796f3c7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActivateTeleport"",
                    ""type"": ""Button"",
                    ""id"": ""ff731e29-1489-48ce-80d2-a73d7ab383af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2214a14-e98a-4e40-a4eb-322001e15eef"",
                    ""path"": ""<XRController>{LeftHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d4c5ee-7213-49d2-b628-92a33d02f25d"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6d7e6f3-22b6-48ea-ba63-d6f0d2ceb281"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlatformerControls"",
                    ""action"": ""ActivateTeleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlatformerControls"",
            ""bindingGroup"": ""PlatformerControls"",
            ""devices"": []
        }
    ]
}");
        // Right Controls
        m_RightControls = asset.FindActionMap("Right Controls", throwIfNotFound: true);
        m_RightControls_ToggleLaser = m_RightControls.FindAction("Toggle Laser", throwIfNotFound: true);
        m_RightControls_ToggleFlashlight = m_RightControls.FindAction("Toggle Flashlight", throwIfNotFound: true);
        m_RightControls_ToggleColor = m_RightControls.FindAction("Toggle Color", throwIfNotFound: true);
        m_RightControls_MovePlatform = m_RightControls.FindAction("Move Platform", throwIfNotFound: true);
        m_RightControls_SpawnCrystal = m_RightControls.FindAction("Spawn Crystal", throwIfNotFound: true);
        m_RightControls_Leap = m_RightControls.FindAction("Leap", throwIfNotFound: true);
        // Left Controls
        m_LeftControls = asset.FindActionMap("Left Controls", throwIfNotFound: true);
        m_LeftControls_Jump = m_LeftControls.FindAction("Jump", throwIfNotFound: true);
        m_LeftControls_ActivateTeleport = m_LeftControls.FindAction("ActivateTeleport", throwIfNotFound: true);
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

    // Right Controls
    private readonly InputActionMap m_RightControls;
    private IRightControlsActions m_RightControlsActionsCallbackInterface;
    private readonly InputAction m_RightControls_ToggleLaser;
    private readonly InputAction m_RightControls_ToggleFlashlight;
    private readonly InputAction m_RightControls_ToggleColor;
    private readonly InputAction m_RightControls_MovePlatform;
    private readonly InputAction m_RightControls_SpawnCrystal;
    private readonly InputAction m_RightControls_Leap;
    public struct RightControlsActions
    {
        private @PlayerControls m_Wrapper;
        public RightControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleLaser => m_Wrapper.m_RightControls_ToggleLaser;
        public InputAction @ToggleFlashlight => m_Wrapper.m_RightControls_ToggleFlashlight;
        public InputAction @ToggleColor => m_Wrapper.m_RightControls_ToggleColor;
        public InputAction @MovePlatform => m_Wrapper.m_RightControls_MovePlatform;
        public InputAction @SpawnCrystal => m_Wrapper.m_RightControls_SpawnCrystal;
        public InputAction @Leap => m_Wrapper.m_RightControls_Leap;
        public InputActionMap Get() { return m_Wrapper.m_RightControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RightControlsActions set) { return set.Get(); }
        public void SetCallbacks(IRightControlsActions instance)
        {
            if (m_Wrapper.m_RightControlsActionsCallbackInterface != null)
            {
                @ToggleLaser.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleLaser;
                @ToggleLaser.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleLaser;
                @ToggleLaser.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleLaser;
                @ToggleFlashlight.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleFlashlight;
                @ToggleFlashlight.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleFlashlight;
                @ToggleFlashlight.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleFlashlight;
                @ToggleColor.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleColor;
                @ToggleColor.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleColor;
                @ToggleColor.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnToggleColor;
                @MovePlatform.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnMovePlatform;
                @MovePlatform.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnMovePlatform;
                @MovePlatform.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnMovePlatform;
                @SpawnCrystal.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnSpawnCrystal;
                @SpawnCrystal.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnSpawnCrystal;
                @SpawnCrystal.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnSpawnCrystal;
                @Leap.started -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnLeap;
                @Leap.performed -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnLeap;
                @Leap.canceled -= m_Wrapper.m_RightControlsActionsCallbackInterface.OnLeap;
            }
            m_Wrapper.m_RightControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleLaser.started += instance.OnToggleLaser;
                @ToggleLaser.performed += instance.OnToggleLaser;
                @ToggleLaser.canceled += instance.OnToggleLaser;
                @ToggleFlashlight.started += instance.OnToggleFlashlight;
                @ToggleFlashlight.performed += instance.OnToggleFlashlight;
                @ToggleFlashlight.canceled += instance.OnToggleFlashlight;
                @ToggleColor.started += instance.OnToggleColor;
                @ToggleColor.performed += instance.OnToggleColor;
                @ToggleColor.canceled += instance.OnToggleColor;
                @MovePlatform.started += instance.OnMovePlatform;
                @MovePlatform.performed += instance.OnMovePlatform;
                @MovePlatform.canceled += instance.OnMovePlatform;
                @SpawnCrystal.started += instance.OnSpawnCrystal;
                @SpawnCrystal.performed += instance.OnSpawnCrystal;
                @SpawnCrystal.canceled += instance.OnSpawnCrystal;
                @Leap.started += instance.OnLeap;
                @Leap.performed += instance.OnLeap;
                @Leap.canceled += instance.OnLeap;
            }
        }
    }
    public RightControlsActions @RightControls => new RightControlsActions(this);

    // Left Controls
    private readonly InputActionMap m_LeftControls;
    private ILeftControlsActions m_LeftControlsActionsCallbackInterface;
    private readonly InputAction m_LeftControls_Jump;
    private readonly InputAction m_LeftControls_ActivateTeleport;
    public struct LeftControlsActions
    {
        private @PlayerControls m_Wrapper;
        public LeftControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_LeftControls_Jump;
        public InputAction @ActivateTeleport => m_Wrapper.m_LeftControls_ActivateTeleport;
        public InputActionMap Get() { return m_Wrapper.m_LeftControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LeftControlsActions set) { return set.Get(); }
        public void SetCallbacks(ILeftControlsActions instance)
        {
            if (m_Wrapper.m_LeftControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnJump;
                @ActivateTeleport.started -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnActivateTeleport;
                @ActivateTeleport.performed -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnActivateTeleport;
                @ActivateTeleport.canceled -= m_Wrapper.m_LeftControlsActionsCallbackInterface.OnActivateTeleport;
            }
            m_Wrapper.m_LeftControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ActivateTeleport.started += instance.OnActivateTeleport;
                @ActivateTeleport.performed += instance.OnActivateTeleport;
                @ActivateTeleport.canceled += instance.OnActivateTeleport;
            }
        }
    }
    public LeftControlsActions @LeftControls => new LeftControlsActions(this);
    private int m_PlatformerControlsSchemeIndex = -1;
    public InputControlScheme PlatformerControlsScheme
    {
        get
        {
            if (m_PlatformerControlsSchemeIndex == -1) m_PlatformerControlsSchemeIndex = asset.FindControlSchemeIndex("PlatformerControls");
            return asset.controlSchemes[m_PlatformerControlsSchemeIndex];
        }
    }
    public interface IRightControlsActions
    {
        void OnToggleLaser(InputAction.CallbackContext context);
        void OnToggleFlashlight(InputAction.CallbackContext context);
        void OnToggleColor(InputAction.CallbackContext context);
        void OnMovePlatform(InputAction.CallbackContext context);
        void OnSpawnCrystal(InputAction.CallbackContext context);
        void OnLeap(InputAction.CallbackContext context);
    }
    public interface ILeftControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnActivateTeleport(InputAction.CallbackContext context);
    }
}
