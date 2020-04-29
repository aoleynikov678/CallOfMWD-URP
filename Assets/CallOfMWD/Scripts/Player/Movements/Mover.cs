using UnityEngine;

namespace lab.mwd
{
    public abstract class Mover
    {
        protected CharacterController characterController;
        protected IPositionProvider positionProvider;
        protected Camera camera;
        
        public virtual void Init(CharacterController characterController, Camera camera, IPositionProvider positionProvider)
        {
            this.characterController = characterController;
            this.camera = camera;
            this.positionProvider = positionProvider;
        }

        public abstract void Tick(Vector2 position, float speed, float gravityMultiplier);
    }


}