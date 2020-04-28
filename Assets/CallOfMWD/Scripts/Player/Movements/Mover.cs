using UnityEngine;

namespace lab.mwd
{
    public abstract class Mover
    {
        protected CharacterController characterController;
        //protected GameObject head;
        protected IPositionProvider positionProvider;
        
        public virtual void Init(CharacterController characterController, IPositionProvider positionProvider)
        {
            this.characterController = characterController;
            this.positionProvider = positionProvider;
        }

        public abstract void Tick(Vector2 position, float speed, float gravityMultiplier);
    }


}