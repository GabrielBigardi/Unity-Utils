using UnityEngine;

public class WalkState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public WalkState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
		_stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        Debug.Log("Walk Tick");
    }
	
    public void FixedTick()
    {
        Debug.Log("Walk Physics Tick");
    }

    public void OnEnter()
    {
        Debug.Log("Walk OnEnter");
    }

    public void OnExit()
    {
        Debug.Log("Walk OnExit");
    }
}
