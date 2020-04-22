using System;
using lab.core;
using UnityEngine;

namespace lab.mwd
{
    public interface IPlayerInputService : IGameService
    {
        Vector2 Move { get; }
    }
}