namespace iLogos.TankSurvival
{
    public interface IPoolable
    {
        void DestroyInstance();
        void ResetInstance();
    }
}