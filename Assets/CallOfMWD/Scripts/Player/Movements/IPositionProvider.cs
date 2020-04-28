using UnityEngine;

namespace lab.mwd
{
    public interface IPositionProvider
    {
        Transform Transform { get; }
        void Init(Transform parent);
        void Tick();
    }
}