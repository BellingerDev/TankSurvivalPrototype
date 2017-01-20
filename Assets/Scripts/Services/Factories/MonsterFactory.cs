using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public sealed class MonsterFactory : AbstractFactory
    {
        [SerializeField]
        private GameObject _monsterPrototype;

        private GameBalance _balance;

        private List<Monster> _spawnedMonsters = new List<Monster>();


        private void Awake()
        {
            _balance = Game.Instance.Balance;
        }

        public void SpawnMonsterAtRandomPosition()
        {
            Vector3 randomPosition = _balance.GetRandomArenaPosition();
            float randomPositionDistance = randomPosition.magnitude;
            float maxDistance = _balance.ArenaSize.magnitude;

            Monster monster = CreateInstance<Monster>(_monsterPrototype);
            monster.transform.position = randomPosition * (maxDistance - randomPositionDistance);
        }

        public void SpawnLevelMonsters()
        {
            for (int i = 0; i < _balance.MaxMonstersOnScene; i ++)
            {
                SpawnMonsterAtRandomPosition();
            }
        }
    }
}