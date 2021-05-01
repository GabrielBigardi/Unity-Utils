public class IdleState : IState
{
    private readonly PlayerEntity _playerEntity;

    public IdleState(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        Debug.Log("Idle Tick");
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