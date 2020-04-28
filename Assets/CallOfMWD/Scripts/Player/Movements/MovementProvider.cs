using lab.core;
using UnityEngine;
using UnityEngine.InputSystem.XR;
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

        protected override void Awake()
        {
            playerInputService = ServiceLocator.Current.Get<IPlayerInputService>();
            mover = new LocoMover();
            positionProvider = new XRPositionProvider();
            positionProvider.Init(transform);
        }

        private void Start()
        {
            var characterController = GetComponent<CharacterController>();
            var head = GetComponent<XRRig>().cameraGameObject;
            
            mover.Init(characterController, positionProvider);
        }

        private void FixedUpdate()
        {
            positionProvider.Tick();
            mover.Tick(playerInputService.Move, speed, gravityMultiplier);
        }
    }
}

