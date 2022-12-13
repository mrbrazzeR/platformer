using System.Collections;
using GamePlay.Effect;
using UnityEngine;

namespace GamePlay.Bot
{
    public class AttackState : BotState
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ChasingState chasingState;


        private BotManager _botManager;
        private CharacterStats _botStats;
        [SerializeField] private Transform attackPoint;


        private void OnEnable()
        {
            _botManager = gameObject.GetComponent<BotManager>();
            _botStats = _botManager.botStats;
        }

        public override BotState RunCurrentState()
        {
            return Attack();
        }
        
        private BotState Attack()
        {
            var hitPlayer =
                Physics2D.OverlapCircleAll(attackPoint.position, _botStats.attackRange, _botManager.playerMask);
            if (hitPlayer.Length == 0)
            {
                return chasingState;
            }

            animator.SetBool(AnimationKey.Moving, false);
            animator.SetTrigger(AnimationKey.Attack);

            return this;
        }

        private void HitDamage()
        {
            var hitPlayer =
                Physics2D.OverlapCircleAll(attackPoint.position, _botStats.attackRange, _botManager.playerMask);
            foreach (var hit in hitPlayer)
            {
                if (hit != null)
                {
                    hit.GetComponent<Player>().EarnDamage(_botStats.damage);
                    var randomize = Random.Range(0, 7);
                    if (randomize == 5)
                    {
                        EffectExecuted(hit.gameObject);
                    }
                }
            }
        }

        private void EffectExecuted(GameObject gameObj)
        {
            if (_botStats.attackType == AttackType.Fire)
            {
                ClientEffect.ClientMethod(new FireEffectCreate(), _botStats, gameObj);
            }

            if (_botStats.attackType == AttackType.Frost)
            {
                ClientEffect.ClientMethod(new FrostEffectCreate(), _botStats, gameObj);
            }

            if (_botStats.attackType == AttackType.Normal)
            {
                ClientEffect.ClientMethod(new NormalEffectCreate(), _botStats, gameObj);
            }
        }
    }
}