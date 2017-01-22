namespace iLogos.TankSurvival
{
    public class Obstacle : AbstractEntity
    {
        public override void ObtainDamage(AbstractBullet bullet)
        {
            base.ObtainDamage(bullet);
            bullet.DestroyInstance();
        }

        public override void ObtainDamage(AbstractEntity entity)
        {
            
        }
    }
}