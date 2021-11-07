using System;
using UnityEngine;
using UniRx;
using Echo.Input;

namespace Echo.Player{
    [RequireComponent(typeof(PlayerBase))]
    public class PlayerReflectBullet : MonoBehaviour{
        
        [SerializeField] private PlayerBase player;
        [SerializeField] private ReflectType type;
        [SerializeField] private float ringRadius;
        [SerializeField] private float ringWidth;
        [SerializeField] private float bulletAcceleration;
        [Range(0, 1)]
        [SerializeField] private float playerMovementRatio;
        [SerializeField] private float cooldownDuration;
        [SerializeField] private float slowmoCharge;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerBullet prefabBullet;
        [SerializeField] private PlayerBullet prefabPiercingBullet;

        private float cooldownTime;

        private void Reset(){
            player = GetComponent<PlayerBase>();
        }

        private void Awake(){
            inputReader.OnNormalAttack.Subscribe(_  => ReflectBullets()).AddTo(this);
        }

        private void Update(){
            if(cooldownTime > 0){
                cooldownTime = Mathf.Max(0, cooldownTime - Time.deltaTime);
            }
        }

        private void ReflectBullets(){
            if(!player) return;
            if(cooldownTime > 0) return;
            bool reflected = false;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, ringRadius + ringWidth / 2)){
                IReflectable reflectable = collider.GetComponent<IReflectable>();
                if(!(reflectable is MonoBehaviour)) continue; // nullチェックも兼ねる
                var monoReflectable = reflectable as MonoBehaviour;
                reflectable.OnReflect(player, type);
                reflected = true;
            }
            if(reflected){
                cooldownTime = cooldownDuration;
                // maybe animate character here
            }
        }

        public void CycleReflectType(){
            type = (ReflectType)(((int)type + 1) % Enum.GetValues(typeof(ReflectType)).Length);
        }

        public void ReflectBullet(BulletBase bulletToReflect, ReflectType reflectType){
            Destroy(bulletToReflect.gameObject);
            PlayerBullet bulletPrefab;
            switch(reflectType){
                case ReflectType.NORMAL:  bulletPrefab = prefabBullet; break;
                case ReflectType.SPECIAL: bulletPrefab = prefabPiercingBullet; break;
                default: throw new NotImplementedException($"No prefab for reflect type {reflectType} exists");
            };
            var bullet = Instantiate(bulletPrefab, bulletToReflect.transform.position, Quaternion.identity);
            var movement = player.Movement;
            if(movement.sqrMagnitude > 0){
                bullet.Direction = Vector3.Lerp(-bulletToReflect.Direction, movement.normalized, playerMovementRatio);
            }else{
                bullet.Direction = -bulletToReflect.Direction;
            }
            bullet.Speed = bulletToReflect.Speed + bulletAcceleration;
            player.ChargeSlowmo(slowmoCharge);
        }

    }
}
