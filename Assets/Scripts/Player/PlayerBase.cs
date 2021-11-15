using System;
using UnityEngine;
using UniRx;
using Echo.Item;
using Echo.Misc;
using Echo.Save;

namespace Echo.Player{
    public sealed class PlayerBase : MonoBehaviour{

        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private IntReactiveProperty health;
        [SerializeField] private IntReactiveProperty level;
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxLevel;
        [SerializeField] private bool halfMaxHealth;
        [SerializeField] private float noDamageDuration;
        [SerializeField] private MaterialFlash flashOnDamage;
        private PlayerReflectBullet reflectBullet;
        private PlayerSlowmo slowmo;
        private PlayerMovement movement;

        private bool isAlive;
        private float noDamageTime;

        private readonly Subject<Unit> onDeath = new Subject<Unit>();

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
        public IObservable<Unit> OnDeath => onDeath;

        public void Damage(int damage, bool force = false){
            if(!force && noDamageTime > 0) return;
            Health -= damage;
            noDamageTime = noDamageDuration;
            if(Health <= 0){
                Die();
            }
            if(flashOnDamage){
                flashOnDamage.Flash();
            }
        }

        public void Die(){
            if(!isAlive) return;
            isAlive = false;
            onDeath.OnNext(Unit.Default);
            saveSystem.SaveData.health = saveSystem.SaveData.maxHealth;
            saveSystem.Save();
            foreach(var bullet in FindObjectsOfType<BulletBase>()){
                Destroy(bullet.gameObject);
            }
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
                case Item.ItemEffectType.LevelUp:          LevelUp(); break;
                case Item.ItemEffectType.CycleBulletType:
                    if(reflectBullet){
                        reflectBullet.ToggleReflectType();
                        Level = 1;
                    }
                    break;
                case Item.ItemEffectType.IncreaseRingSize: 
                    if(reflectBullet){
                        reflectBullet.RingWidthLevel ++;
                    }
                    break;
                default: throw new NotImplementedException($"Item effect {itemInfo.Effect} not implemented");
            }
        }

        private void LevelUp(){
            if(reflectBullet && reflectBullet.ReflectType == ReflectType.NORMAL){
                reflectBullet.ReflectType = ReflectType.SPREADING;
                Level = 1;
            }else{
                Level ++;
            }
        }

        private void Awake(){
            movement = GetComponent<PlayerMovement>();
            reflectBullet = GetComponent<PlayerReflectBullet>();
            slowmo = GetComponent<PlayerSlowmo>();
            maxHealth = saveSystem.SaveData.maxHealth;
            if(halfMaxHealth){
                maxHealth = Mathf.Max(1, maxHealth / 2);
            }
            health.Value = maxHealth;
        }

        private void Start(){
            isAlive = true;
        }

        private void Update(){
            if(noDamageTime > 0){
                noDamageTime = Mathf.Max(0, noDamageTime - Time.deltaTime);
            }
        }

    }
}
