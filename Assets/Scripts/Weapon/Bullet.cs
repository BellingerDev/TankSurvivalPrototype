using UnityEngine;


namespace iLogos.TankSurvival
{
    public class Bullet : MonoBehaviour
    {
        public float Damage { get; private set; }
        public Vector3 Velocity { get; private set; }


        public void Configure(float damage, Vector3 velocity)
        {
            Damage = damage;
            Velocity = velocity;
        }
    }
}