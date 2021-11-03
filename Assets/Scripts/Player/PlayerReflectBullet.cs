using System;
using UnityEngine;

namespace Echo.Player{
    public class PlayerReflectBullet : MonoBehaviour{
        
        private GameInput inputActions;
        private PlayerBase player;
        [SerializeField] private float ringRadius;
        [SerializeField] private float ringWidth;
        [SerializeField] private float bulletAcceleration;
        [Range(0, 1)]
        [SerializeField] private float playerMovementRatio;
        [SerializeField] private PlayerBullet prefabBullet;
        [SerializeField] private PlayerBullet prefabPiercingBullet;

        private void Awake(){
            inputActions = new GameInput();
            inputActions.Player.NormalAttack.performed  += ctx => ReflectBullets(ReflectType.NORMAL);
            inputActions.Player.SpecialAttack.performed += ctx => ReflectBullets(ReflectType.SPECIAL);
        }

        private void OnEnable(){
            inputActions.Enable();
        }

        private void OnDisable(){
            inputActions.Disable();
        }

        public void Init(PlayerBase player){
            this.player = player;
        }

        private void ReflectBullets(ReflectType reflectType){
            if(!player) return;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, ringRadius + ringWidth / 2)){
                IReflectable reflectable = collider.GetComponent<IReflectable>();
                if(!(reflectable is MonoBehaviour)) continue; // nullチェックも兼ねる
                var monoReflectable = reflectable as MonoBehaviour;
                reflectable.OnReflect(player, reflectType);
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
