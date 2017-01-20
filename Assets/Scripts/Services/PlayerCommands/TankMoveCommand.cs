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

        private float _linearVelocity;
        private Quaternion _angularVelocity;


        public override bool IsHandle()
        {
            // calculate rotation
            if (Input.GetKeyDown(_leftKey))
                _angularVelocity *= Quaternion.Euler(Vector3.down);
            
            if (Input.GetKeyDown(_rightKey))
                _angularVelocity *= Quaternion.Euler(Vector3.up);

            if (Input.GetKeyUp(_leftKey) || Input.GetKeyUp(_rightKey))
                _angularVelocity = Quaternion.identity;

            // calculate position
            if (Input.GetKeyDown(_topKey))
                _linearVelocity = 1.0f;

            if (Input.GetKeyDown(_bottomKey))
                _linearVelocity = -1.0f;
            
            if (Input.GetKeyUp(_topKey) || Input.GetKeyUp(_bottomKey))
                _linearVelocity = 0.0f;

            return true;
        }

        public override void Execute(Tank tank)
        {
            tank.LinearVelocity = _linearVelocity;
            tank.AngularVelocity = _angularVelocity;
        }
    }
}