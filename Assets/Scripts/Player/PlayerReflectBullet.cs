using UnityEngine;
using Echo.Enemy;

namespace Echo.Player{
    public class PlayerReflectBullet : MonoBehaviour{
        
        private GameInput inputActions;
        private PlayerBase player;
        [SerializeField] private float ringRadius;
        [SerializeField] private float ringWidth;
        [SerializeField] private float bulletAcceleration;
        [SerializeField] private PlayerBullet bulletPrefab;

        private void Awake(){
            inputActions = new GameInput();
            inputActions.Player.Reflect.performed += ctx => ReflectBullets();
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

        private void ReflectBullets(){
            if(!player) return;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, ringRadius + ringWidth / 2)){
                IReflectable reflectable = collider.GetComponent<IReflectable>();
                if(!(reflectable is MonoBehaviour)) continue; // nullチェックも兼ねる
                var monoReflectable = reflectable as MonoBehaviour;
                reflectable.OnReflect(player);
            }
        }

        public void ReflectBullet(EnemyBullet enemyBullet){
            Destroy(enemyBullet.gameObject);
            var bullet = Instantiate(bulletPrefab, enemyBullet.transform.position, Quaternion.identity);
            bullet.Direction = enemyBullet.Shooter.transform.position - transform.position;
            bullet.Speed = enemyBullet.Speed + bulletAcceleration;
        }

    }
}
