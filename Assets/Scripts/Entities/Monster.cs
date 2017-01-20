using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class Monster : AbstractEntity
    {
        public static event Action OnDestroyedEvent = delegate { };

        [SerializeField]
        private float _moveSpeed;


        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            if (Game.Instance.ActiveTank != null)
            {
                Vector3 position = this.transform.position;

                Vector3 tankPosition = Game.Instance.ActiveTank.transform.position;

                position = Vector3.MoveTowards(position, tankPosition, Time.deltaTime * _moveSpeed);


                this.transform.position = position;
                this.transform.LookAt(tankPosition);
            }
        }

        #endregion

        public override void DestroyInstance()
        {
            this.gameObject.SetActive(false);

            OnDestroyedEvent();

            Destroy(this.gameObject);
        }
    }
}
