using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithDelay : GameEventListener, IGameEventListener
{
    [SerializeField] private float _delay = 1f;

    private void Awake() => gameEvent.Register(this);
    private void OnDestroy() => gameEvent.Deregister(this);

    public override void RaiseEvent()
    {
        unityEvent.Invoke();
        StartCoroutine(RunDelayedEvent());
    }

    private IEnumerator RunDelayedEvent()
    {
        yield return new WaitForSeconds(_delay);
        unityEvent?.Invoke();
    }
}
