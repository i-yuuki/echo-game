using System;
using UnityEngine;
using UniRx;
using Echo.Item;

namespace Echo.Player{
    public class PlayerBase : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private int maxHealth;
        [SerializeField] private PlayerReflectBullet reflectBullet;
        [SerializeField] private PlayerMovement movement;

        public int Health{
            get => health.Value;
            private set => health.Value = Mathf.Clamp(value, 0, MaxHealth);
        }
        public int MaxHealth => maxHealth;
        public Vector3 Movement => movement ? movement.Movement : Vector3.zero;
        public IObservable<int> OnHealthChange => health;

        public void Damage(int damage){
            Health -= damage;
        }

        public void ReflectBullet(BulletBase bullet, ReflectType reflectType){
            if(reflectBullet){
                reflectBullet.ReflectBullet(bullet, reflectType);
            }
        }

        public void ApplyItemEffect(ItemInfo itemInfo){
            switch(itemInfo.Effect){
                case Item.ItemEffectType.None: break;
                case Item.ItemEffectType.Heal:             Health ++; break;
                case Item.ItemEffectType.LevelUp:          /* TODO */ break;
                case Item.ItemEffectType.CycleBulletType:  /* TODO */ break;
                case Item.ItemEffectType.IncreaseRingSize: /* TODO */ break;
                default: throw new NotImplementedException($"Item effect {itemInfo.Effect} not implemented");
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
