using System;
using System.Collections;
using GamePlay.Effect;
using UnityEngine;

namespace GamePlay
{
    public class Player : MonoBehaviour, IEarnEffect, IEarnDamage
    {
        //playerStat
        [SerializeField] private CharacterStats playerStats;


        [SerializeField] private ParticleSystem fireEffect;
        private int _baseSpeed;

        //enemy attack
        private float _currentTime;


        private void Awake()
        {
            _baseSpeed = playerStats.speed;
        }

        public void EarnEffected(int damage, float time, AttackType attackType)
        {
            StartCoroutine(EarnEffect(damage, time, attackType));
        }

        private void Update()
        {
            if (fireEffect.isPlaying)
            {
                fireEffect.transform.position = transform.position;
            }
        }

        private IEnumerator EarnEffect(int damage, float time, AttackType attackType)
        {
            switch (attackType)
            {
                case AttackType.Fire:
                {
                    while (_currentTime < time)
                    {
                        Debug.Log("earn Effect and damage" + damage);
                        fireEffect.transform.position = transform.position;
                        fireEffect.Play();
                        yield return new WaitForSeconds(0.2f);
                        _currentTime += 0.1f;
                    }

                    _currentTime = 0;
                    fireEffect.Stop();
                    break;
                }
                case AttackType.Frost:
                {
                    while (_currentTime < time)
                    {
                        Debug.Log("earn Effect and damage" + damage);
                        playerStats.speed -= 1;
                        Debug.Log("enemy slowed, current speed: " + playerStats.speed);
                        yield return new WaitForSeconds(0.2f);
                        _currentTime += 0.1f;
                    }

                    playerStats.speed = _baseSpeed;
                    _currentTime = 0;
                    break;
                }
                case AttackType.Normal:
                {
                    {
                        Debug.Log("earn Effect and damage" + damage);
                        yield return new WaitForSeconds(0.2f);
                        _currentTime = 0;
                    }

                    break;
                }
            }
        }

        public void EarnDamage(int damage)
        {
            Debug.Log(damage);
        }
    }
}