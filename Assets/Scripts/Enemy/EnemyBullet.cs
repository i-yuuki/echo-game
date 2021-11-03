using UnityEngine;
using Echo.Player;

namespace Echo.Enemy{
    [RequireComponent(typeof(BulletBase))]
    public sealed class EnemyBullet : MonoBehaviour, IReflectable, IBullet{

        [SerializeField] private BulletBase bullet;
        [SerializeField] private float lifetime = 5;
        private Transform shooter;

        public Transform Shooter{
            get => shooter;
            set => shooter = value;
        }
        public Vector3 Direction{
            get => bullet.Direction;
            set => bullet.Direction = value;
        }
        public float Speed{
            get => bullet.Speed;
            set => bullet.Speed = value;
        }

        private void Reset(){
            bullet = GetComponent<BulletBase>();
        }

        private void Update(){
            if(!shooter){
                Destroy(gameObject);
                return;
            }
            lifetime -= Time.deltaTime;
            if(lifetime <= 0 || !shooter){
                Destroy(gameObject);
                return;
            }
        }

        private void OnCollisionEnter(Collision other){
            var player = other.gameObject.GetComponent<PlayerBase>();
            if(player == null){
                bullet.Bounce(other.contacts[0].normal);
            }else{
                Destroy(gameObject);
                player.Damage(1);
            }
        }

        void IReflectable.OnReflect(PlayerBase player, ReflectType reflectType){
            player.ReflectBullet(bullet, reflectType);
        }

    }
}
