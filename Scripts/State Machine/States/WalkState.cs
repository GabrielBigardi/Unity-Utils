public class WalkState : IState
{
    private readonly PlayerEntity _playerEntity;

    public WalkState(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        Debug.Log("Walk Tick");
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