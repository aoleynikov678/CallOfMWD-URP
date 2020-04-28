using System;
using lab.core;
using UnityEngine;
using IDisposable = System.IDisposable;

namespace lab.mwd
{
    [AutoDispose(typeof(Action))]
    public class PlayerInputService : IPlayerInputService, ITickable, IDisposable
    {
        private readonly PlayerInputActions playerInputActions;
        public Vector2 Move { get; private set; }
        public Vector2 VerticalMove { get; private set; }

        private Vector2 move;
        private bool movePressed = false;

        public PlayerInputService()
        {
            playerInputActions = new PlayerInputActions();
            
            playerInputActions.PlayerControls.MovePress.performed += ctx => movePressed = true;
            playerInputActions.PlayerControls.MovePress.canceled += ctx => movePressed = false;

            playerInputActions.PlayerControls.Move.performed += ctx => move = ctx.ReadValue<Vector2>();

            playerInputActions.PlayerControls.VericalMove.performed += ctx => VerticalMove = ctx.ReadValue<Vector2>();
            
            playerInputActions.Enable();
        }

        public void Tick()
        {
            Move = movePressed ? move : Vector2.zero;
        }
        
        public void Dispose()
        {
            playerInputActions.Disable();
        }
    }
}