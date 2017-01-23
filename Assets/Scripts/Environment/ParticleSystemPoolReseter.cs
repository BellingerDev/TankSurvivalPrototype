using UnityEngine;


namespace iLogos.TankSurvival
{
    public class ParticleSystemPoolReseter : MonoBehaviour, IPoolable
    {
        private ParticleSystem _ps;


        private void Awake()
        {
            _ps = GetComponent<ParticleSystem>();
        }

        public void DestroyInstance()
        {
            Pool.Instance.Retrieve(this.gameObject);
        }

        public void ResetInstance()
        {
            _ps.Clear();
        }
    }
}
