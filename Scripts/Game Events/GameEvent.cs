using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener
{
    void RaiseEvent();
}

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    private HashSet<IGameEventListener> _listeners = new HashSet<IGameEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in _listeners)
        {
            globalEventListener.RaiseEvent();
        }
    }

    public void Register(IGameEventListener gameEventListener) => _listeners.Add(gameEventListener);
    public void Deregister(IGameEventListener gameEventListener) => _listeners.Remove(gameEventListener);
}
