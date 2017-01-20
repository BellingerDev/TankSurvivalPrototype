namespace iLogos.TankSurvival
{
    public abstract class AbstractPlayerCommand
    {
        public abstract bool IsHandle();
        public abstract void Execute(Tank tank);
    }
}