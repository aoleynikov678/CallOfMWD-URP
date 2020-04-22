using UnityEngine;

namespace lab.mwd
{
    public abstract class Mover
    {
        protected CharacterController characterController;
        protected GameObject head;
        
        public virtual void Init(CharacterController characterController, GameObject head)
        {
            this.characterController = characterController;
            this.head = head;
        }

        public abstract void Tick(Vector2 position, float speed, float gravityMultiplier);
    }
}