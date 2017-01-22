using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public sealed class MonsterFactory : AbstractFactory
    {
        [SerializeField]
        private GameObject _monsterPrototype;


        public void SpawnMonsterAtRandomPosition()
        {
            GameBalance _balance = Game.Instance.Balance;

            Vector3 randomPosition = _balance.GetRandomArenaPosition();
            float maxDistance = _balance.ArenaSize.magnitude;

            Monster monster = CreateInstance<Monster>(_monsterPrototype);
			monster.transform.position = randomPosition.normalized * maxDistance;
        }

        public void SpawnLevelMonsters()
        {
            GameBalance _balance = Game.Instance.Balance;
            
            for (int i = 0; i < _balance.MaxMonstersOnScene; i ++)
            {
                SpawnMonsterAtRandomPosition();
            }
        }
    }
}