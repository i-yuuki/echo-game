using System;
using UnityEngine;
using UniRx;
using Echo.Input;

namespace Echo.Player{
    public class PlayerReflectBullet : MonoBehaviour{
        
        private PlayerBase player;
        [SerializeField] private float ringRadius;
        [SerializeField] private float ringWidth;
        [SerializeField] private float bulletAcceleration;
        [Range(0, 1)]
        [SerializeField] private float playerMovementRatio;
        [SerializeField] private float cooldownDuration;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerBullet prefabBullet;
        [SerializeField] private PlayerBullet prefabPiercingBullet;

        private float cooldownTime;

        private void Awake(){
            inputReader.OnNormalAttack.Subscribe(_  => ReflectBullets(ReflectType.NORMAL)).AddTo(this);
            inputReader.OnSpecialAttack.Subscribe(_ => ReflectBullets(ReflectType.SPECIAL)).AddTo(this);
        }

        private void Update(){
            if(cooldownTime > 0){
                cooldownTime = Mathf.Max(0, cooldownTime - Time.deltaTime);
            }
        }

        public void Init(PlayerBase player){
            this.player = player;
        }

        private void ReflectBullets(ReflectType reflectType){
            if(!player) return;
            if(cooldownTime > 0) return;
            bool reflected = false;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, ringRadius + ringWidth / 2)){
                IReflectable reflectable = collider.GetComponent<IReflectable>();
                if(!(reflectable is MonoBehaviour)) continue; // nullチェックも兼ねる
                var monoReflectable = reflectable as MonoBehaviour;
                reflectable.OnReflect(player, reflectType);
                reflected = true;
            }
            if(reflected){
                cooldownTime = cooldownDuration;
                // maybe animate character here
            }
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
        }

    }
}
