namespace Assets.CodeBase.App.StateMachine
{
    public interface IState
    {
        void Exit();
    }

    public interface IParameterizedState : IState
    {
        void Enter<T>(T data);
    }

    public interface INoneParameterizedState : IState
    {
        void Enter();
    }
}
