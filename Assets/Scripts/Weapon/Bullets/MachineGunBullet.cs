namespace iLogos.TankSurvival
{
    public class MachineGunBullet : AbstractBullet
    {
        public override float ReceiveDamage()
        {
            DestroyInstance();

            return Damage;
        }
    }
}