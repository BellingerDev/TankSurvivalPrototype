namespace iLogos.TankSurvival
{
    public class MachineGunBullet : AbstractBullet
    {
        public override int ReceiveDamage()
        {
            DestroyInstance();

            return Damage;
        }
    }
}