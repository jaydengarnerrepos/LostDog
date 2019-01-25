using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameEvent), menuName = "Scriptables/Events/" + nameof(GameEvent))]
class GameEvent : ScriptableObject
{
    public event Action Raised;

    public void Raise()
    {
        Raised?.Invoke();
    }
}

class GameEvent<T> : ScriptableObject
{
    public event Action<T> Raised;

    public void Raise(T args)
    {
        Raised?.Invoke(args);
    }
}