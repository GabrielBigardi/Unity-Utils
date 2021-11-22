using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] protected GameEvent gameEvent;
    [SerializeField] protected UnityEvent unityEvent;

    private void Awake() => gameEvent.Register(this);
    private void OnDestroy() => gameEvent.Deregister(this);
    public virtual void RaiseEvent() => unityEvent?.Invoke();
}
