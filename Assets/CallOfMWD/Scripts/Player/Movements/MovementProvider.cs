using lab.core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace lab.mwd
{ 
    public class MovementProvider : LocomotionProvider
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private float gravityMultiplier = 1;

        private IPlayerInputService playerInputService;
        private IPositionProvider positionProvider;
        private Mover mover;
        private PlayerCameraModeSwitcher playerCameraModeSwitcher;
        private Camera mainCamera;
        
        protected override void Awake()
        {
            playerInputService = ServiceLocator.Current.Get<IPlayerInputService>();
            mainCamera = GetComponent<XRRig>().cameraGameObject.GetComponent<Camera>();

            mover = new LocoMover();
            positionProvider = new XRPositionProvider();
            positionProvider.Init(transform, mainCamera);
            
            playerCameraModeSwitcher = new PlayerCameraModeSwitcher(mainCamera);
        }

        private void Start()
        {
            var characterController = GetComponent<CharacterController>();
            mover.Init(characterController, mainCamera, positionProvider);
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerCameraModeSwitcher.SetToVR();
                positionProvider = new XRPositionProvider();
                positionProvider.Init(transform, mainCamera);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerCameraModeSwitcher.SetToDisplay();
                positionProvider = new KeyboardPositionProvider();
                positionProvider.Init(transform, mainCamera);
            }
            
            positionProvider.Tick();
            mover.Tick(playerInputService.Move, speed, gravityMultiplier);
        }
    }
}

