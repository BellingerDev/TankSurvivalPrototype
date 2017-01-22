namespace iLogos.TankSurvival
{
    public class Obstacle : AbstractEntity
    {
        public override void ObtainDamage(AbstractBullet bullet)
        {
            base.ObtainDamage(bullet);

			// destroy all types of bullets when collide with obstacle
            bullet.DestroyInstance();
        }

        public override void ObtainDamage(AbstractEntity entity)
        {
            // override for skip damage from other entities
        }
    }
}