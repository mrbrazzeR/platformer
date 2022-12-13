using System;
using UnityEngine;

namespace GamePlay.Bot
{
    public class ChasingState : BotState
    {
        [SerializeField] private PatrolState patrolState;
        [SerializeField] private AttackState attackState;
        [SerializeField] private Transform[] patrolPosition;


        private Player _player;
        private BotManager _botManager;
        private CharacterStats _botStats;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private Animator animator;

        private void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _botManager = gameObject.GetComponent<BotManager>();
            _botStats = _botManager.botStats;
        }

        public override BotState RunCurrentState()
        {
            Chasing();
            return Chase();
        }

        private BotState Chase()
        {
            if (Vector2.Distance(transform.position, _player.transform.position) > _botStats.chaseDistance)
            {
                return patrolState;
            }

            if (transform.position.x > patrolPosition[1].position.x)
            {
                if (Vector2.Distance(transform.position, patrolPosition[1].position) > _botStats.maxDistance)
                {
                    return patrolState;
                }
            }

            if (transform.position.x < patrolPosition[0].position.x)
            {
                if (Vector2.Distance(transform.position, patrolPosition[0].position) > _botStats.maxDistance)
                {
                    return patrolState;
                }
            }

            return AttackState();
        }

        private void Chasing()
        {
            animator.SetBool(AnimationKey.Moving, true);
            if (transform.position.x > _player.transform.position.x)
            {
                transform.position += Vector3.left * (_botStats.chaseSpeed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }

            else if (transform.position.x < _player.transform.position.x)
            {
                transform.position += Vector3.right * (_botStats.chaseSpeed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        private BotState AttackState()
        {
            var hitPlayer =
                Physics2D.OverlapCircleAll(attackPoint.position, _botStats.attackRange, _botManager.playerMask);
            if (hitPlayer.Length > 0)
            {
                return attackState;
            }

            return this;
        }
    }
}