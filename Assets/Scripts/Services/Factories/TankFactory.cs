using UnityEngine;


namespace iLogos.TankSurvival
{
    public sealed class TankFactory : AbstractFactory
    {
        [SerializeField]
        private GameObject _tankPrototype;


        public Tank SpawnTankAtPosition(Vector3 position)
        {
            Tank tank = CreateInstance<Tank>(_tankPrototype);
            
            tank.transform.position = position;

            return tank;
        }
    }
}