using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    private StateMachine _stateMachine;
    private IdleState _idleState;
    private WalkState _walkState;
	
	public StateMachine stateMachine => _stateMachine;
	public IdleState idleState => _idleState;
    public WalkState walkState => _walkState;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, this);
        _walkState = new WalkState(_stateMachine, this);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }
	
	private void FixedUpdate()
	{
		_stateMachine.FixedTick();
	}
}
