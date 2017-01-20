using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankMoveCommand : AbstractPlayerCommand
    {
        [SerializeField]
        private KeyCode _leftKey;
        
        
        [SerializeField]
        private KeyCode _rightKey;

        
        [SerializeField]
        private KeyCode _topKey;

        
        [SerializeField]
        private KeyCode _bottomKey;

        private Vector3 _velocity;


        public override bool IsHandle()
        {
            bool isHandle = false;
            _velocity = Vector3.zero;

            if (Input.GetKeyDown(_leftKey))
            {
                _velocity += Vector3.left;
                isHandle = true;
            }

            if (Input.GetKeyDown(_rightKey))
            {
                _velocity += Vector3.right;
                isHandle = true;
            }

            if (Input.GetKeyDown(_topKey))
            {
                _velocity += Vector3.forward;
                isHandle = true;
            }

            if (Input.GetKeyDown(_bottomKey))
            {
                _velocity += Vector3.back;
                isHandle = true;
            }

            return isHandle;
        }

        public override void Execute(Tank tank)
        {
            tank.Move(_velocity);
        }
    }
}