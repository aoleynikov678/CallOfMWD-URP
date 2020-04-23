using UnityEngine;

namespace lab.mwd
{
    public class LocoMover : Mover
    {
        public override void Init(CharacterController characterController, GameObject head)
        {
            base.Init(characterController, head);

            SetupCharacterController();
        }

        public override void Tick(Vector2 position, float speed, float gravityMultiplier)
        {
            SetupCharacterController();
            Move(position, speed);
            ApplyGravity(gravityMultiplier);
        }

        private void SetupCharacterController()
        {
            // Get the head in local, playspace ground
            float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);

            characterController.height = headHeight;

            // Cut in half, add skin
            Vector3 newCenter = Vector3.zero;
            newCenter.y = characterController.height / 2;
            newCenter.y += characterController.skinWidth;

            // Let's move the capsule in local space as well
            newCenter.x = head.transform.localPosition.x;
            newCenter.z = head.transform.localPosition.z;

            // Apply
            characterController.center = newCenter;
        }

        private void Move(Vector2 position, float speed)
        {
            // Apply the touch position to the head's forward Vector
            Vector3 direction = new Vector3(position.x, 0, position.y);
            Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);
            
            // Rotate the input direction by the horizontal head rotation
            direction = Quaternion.Euler(headRotation) * direction;

            // Apply speed and move
            Vector3 movement = direction * speed;
            characterController.Move(movement * Time.deltaTime);
        }

        private void ApplyGravity(float gravityMultiplier)
        {
            Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier,0);
            gravity.y *= Time.fixedDeltaTime;

            characterController.Move(gravity * Time.fixedDeltaTime);
        }
    }
    
}