using System;
using UnityEngine;
using UniRx;

namespace Echo.Player{
    public class PlayerBase : MonoBehaviour{

        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private int maxHealth;
        [SerializeField] private PlayerReflectBullet reflectBullet;

        public int Health{
            get => health.Value;
            private set => health.Value = value;
        }
        public int MaxHealth => maxHealth;
        public IObservable<int> OnHealthChange => health;

        public void Damage(int damage){
            Health -= damage;
        }

        void Start(){
            reflectBullet?.Init(this);
        }

        void Update(){
        }

    }
}
