using System;
using UnityEngine;
using UnityEngine.AI;


namespace iLogos.TankSurvival
{
    public class Monster : AbstractEntity
    {
        public static event Action OnDestroyedEvent = delegate { };

        [SerializeField]
        private float _moveSpeed;

        private NavMeshAgent _agent;


        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            _agent = GetComponent<NavMeshAgent>();
        }

        protected override void Update()
        {
            if (Game.Instance.ActiveTank != null)
            {
                Vector3 tankPosition = Game.Instance.ActiveTank.transform.position;

                _agent.SetDestination(tankPosition);
				_agent.speed = _moveSpeed;
                this.transform.LookAt(tankPosition);
            }
        }

        #endregion

        public override void DestroyInstance()
        {
            base.DestroyInstance();
            OnDestroyedEvent();
        }
    }
}
