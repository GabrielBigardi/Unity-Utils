using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithDelay : GameEventListener
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private UnityEvent _delayedUnityEvent;

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
        _delayedUnityEvent.Invoke();
    }
}
