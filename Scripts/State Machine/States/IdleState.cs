using UnityEngine;

public class IdleState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public IdleState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
		_stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        Debug.Log("Idle Tick");
    }
	
    public void FixedTick()
    {
        Debug.Log("Idle Physics Tick");
    }

    public void OnEnter()
    {
        Debug.Log("Idle OnEnter");
    }

    public void OnExit()
    {
        Debug.Log("Idle OnExit");
    }
}
