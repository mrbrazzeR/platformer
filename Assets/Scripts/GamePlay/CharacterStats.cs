using System;
using GamePlay.Effect;

namespace GamePlay
{
    [Serializable]
    public class CharacterStats
    {
        public int damage;
        public int health;
        public int speed;
        public float chaseSpeed;
        public int strength;
        public int intelligence;
        public float chaseDistance;
        public float maxDistance;
        public float attackRange;
        public AttackType attackType;
        public float timeEffect;
    }
}