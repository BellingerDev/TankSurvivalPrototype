using UnityEngine;


namespace iLogos.TankSurvival
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField]
        private string _id;


        public string Id
        {
            get { return _id; }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(this.transform.position, Vector3.one * 0.1f);
            Gizmos.DrawRay(this.transform.position, this.transform.forward);
        }
    }
}