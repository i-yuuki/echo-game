using System;
using UnityEngine;
using UniRx;
using Echo.Item;

namespace Echo.Player{
    public class PlayerBase : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private IntReactiveProperty level;
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxLevel;
        [SerializeField] private float noDamageDuration;
        private PlayerReflectBullet reflectBullet;
        private PlayerSlowmo slowmo;
        private PlayerMovement movement;

        private float noDamageTime;

        public int Health{
            get => health.Value;
            private set => health.Value = Mathf.Clamp(value, 0, MaxHealth);
        }
        public int MaxHealth => maxHealth;
        public int Level{
            get => level.Value;
            private set => level.Value = Mathf.Clamp(value, 1, MaxLevel);
        }
        public int MaxLevel => maxLevel;
        public Vector3 Movement => movement ? movement.Movement : Vector3.zero;
        public IObservable<int> OnHealthChange => health;
        public IObservable<int> OnLevelChange => level;

        public void Damage(int damage, bool force = false){
            if(!force && noDamageTime > 0) return;
            Health -= damage;
            noDamageTime = noDamageDuration;
        }

        public void ReflectBullet(BulletBase bullet, ReflectType reflectType){
            if(reflectBullet){
                reflectBullet.ReflectBullet(bullet, reflectType);
            }
        }

        public void StopSlowmo(){
            if(slowmo){
                slowmo.StopSlowmo();
            }
        }

        public void ChargeSlowmo(float amount){
            if(slowmo){
                slowmo.Charge += amount;
            }
        }

        public void ApplyItemEffect(ItemInfo itemInfo){
            switch(itemInfo.Effect){
                case Item.ItemEffectType.None: break;
                case Item.ItemEffectType.Heal:             Health ++; break;
                case Item.ItemEffectType.LevelUp:          Level ++; break;
                case Item.ItemEffectType.CycleBulletType:
                    if(reflectBullet){
                        reflectBullet.CycleReflectType();
                        Level = 1;
                    }
                    break;
                case Item.ItemEffectType.IncreaseRingSize: /* TODO */ break;
                default: throw new NotImplementedException($"Item effect {itemInfo.Effect} not implemented");
            }
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            Damage(1);
        }

        private void Awake(){
            movement = GetComponent<PlayerMovement>();
            reflectBullet = GetComponent<PlayerReflectBullet>();
            slowmo = GetComponent<PlayerSlowmo>();
        }

        private void Update(){
            if(noDamageTime > 0){
                noDamageTime = Mathf.Max(0, noDamageTime - Time.deltaTime);
            }
        }

    }
}
