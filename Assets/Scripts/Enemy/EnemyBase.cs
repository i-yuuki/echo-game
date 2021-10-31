﻿using System;
using UnityEngine;
using UniRx;
using Echo.Player;

namespace Echo.Enemy{
    public class EnemyBase : MonoBehaviour
    {

        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private int maxHealth;
        private bool isAlive;

        private readonly Subject<Unit> onDeath = new Subject<Unit>();

        public int Health{
            get => health.Value;
            private set => health.Value = value;
        }
        public int MaxHealth => maxHealth;

        public IObservable<int> OnHealthChange => health;
        public IObservable<Unit> OnDeath => onDeath;

        private void Start(){
            isAlive = true;
        }

        public void Damage(int damage){
            Health -= damage;
            if(damage <= 0){
                onDeath.OnNext(Unit.Default);
            }
        }

        private void Die(){
            if(!isAlive) return;
            isAlive = false;
            Destroy(gameObject);
            onDeath.OnNext(Unit.Default);
        }

    }
}
