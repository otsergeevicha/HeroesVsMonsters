namespace Source.Scripts.Infrastructure.Structs
{
    public readonly struct SignalOnGameEnded
    {
        public readonly bool IsWin;

        public SignalOnGameEnded(bool isWin) => 
            IsWin = isWin;
    }
}