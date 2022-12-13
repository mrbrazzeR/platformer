using System;
using DataBase;
using UnityEngine;

namespace GamePlay.Bot
{
    public class PatrolState : BotState
    {
        [SerializeField] private Transform[] patrolPosition;
        [SerializeField] private ChasingState chasingState;
        [SerializeField] private int patrolDestination;
        [SerializeField] private Animator animator;

        private Player _player;
        private BotManager _botManager;
        private CharacterStats _botStats;

        private void OnEnable()
        {
            animator.SetBool(AnimationKey.Moving, true);
            _player = FindObjectOfType<Player>();
            _botManager = gameObject.GetComponent<BotManager>();
            _botStats = _botManager.botStats;
        }

        public override BotState RunCurrentState()
        {
            Patrol();
            return Patrolling();
        }

        private BotState Patrolling()
        {
            if (transform.position.x > patrolPosition[1].position.x)
            {
                if (Vector2.Distance(transform.position, patrolPosition[1].position) > _botStats.maxDistance)
                {
                    return this;
                }
            }

            if (transform.position.x < patrolPosition[0].position.x)
            {
                if (Vector2.Distance(transform.position, patrolPosition[0].position) > _botStats.maxDistance)
                {
                    return this;
                }
            }

            if (Vector2.Distance(transform.position, _player.transform.position) < _botStats.chaseDistance)
            {
                return chasingState;
            }

            return this;
        }

        private void Patrol()
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPosition[0].position,
                    _botStats.speed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 180, 0, 0);
                if (Vector2.Distance(transform.position, patrolPosition[0].position) < 0.2f)
                {
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPosition[1].position,
                    _botStats.speed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                if (Vector2.Distance(transform.position, patrolPosition[1].position) < 0.2f)
                {
                    patrolDestination = 0;
                }
            }
        }
    }
}