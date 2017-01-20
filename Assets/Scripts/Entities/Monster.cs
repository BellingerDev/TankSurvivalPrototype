using System;


namespace iLogos.TankSurvival
{
    public class Monster : AbstractEntity
    {
        public static event Action OnDestroyedEvent = delegate { };

        public override void DestroyInstance()
        {
            this.gameObject.SetActive(false);

            OnDestroyedEvent();

            Destroy(this.gameObject);
        }
    }
}