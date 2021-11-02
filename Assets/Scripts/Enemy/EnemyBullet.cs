using UnityEngine;
using Echo.Player;

namespace Echo.Enemy{
    public sealed class EnemyBullet : MonoBehaviour, IReflectable{

        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float speed = 1;
        [SerializeField] private float lifetime = 5;
        private Transform shooter;
        private Transform target;
        private Vector3 direction;

        public Transform Shooter{
            get => shooter;
            set => shooter = value;
        }
        public Vector3 Direction{
            get => direction;
            set => direction = value.normalized;
        }
        public float Speed{
            get => speed;
            set => speed = value;
        }

        void Start(){
            rigidbody = GetComponentInChildren<Rigidbody>();
        }

        void Update(){
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

        private void FixedUpdate(){
            rigidbody.velocity = direction * speed;
        }

        void IReflectable.OnReflect(PlayerBase player){
            player.ReflectBullet(this);
        }

    }
}
