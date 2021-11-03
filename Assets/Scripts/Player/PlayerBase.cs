﻿using System;
using UnityEngine;
using UniRx;
using Echo.Enemy;

namespace Echo.Player{
    public class PlayerBase : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private int maxHealth;
        [SerializeField] private PlayerReflectBullet reflectBullet;
        [SerializeField] private PlayerMovement movement;

        public int Health{
            get => health.Value;
            private set => health.Value = value;
        }
        public int MaxHealth => maxHealth;
        public Vector3 Movement => movement ? movement.Movement : Vector3.zero;
        public IObservable<int> OnHealthChange => health;

        public void Damage(int damage){
            Health -= damage;
        }

        public void ReflectBullet(BulletBase bullet){
            if(reflectBullet){
                reflectBullet.ReflectBullet(bullet);
            }
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            Damage(1);
        }

        void Start(){
            reflectBullet?.Init(this);
        }

        void Update(){
        }

    }
}
