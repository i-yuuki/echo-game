using UnityEngine;

namespace Echo{
    public class BulletBase : MonoBehaviour, IBullet{

        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed = 1;
        [SerializeField] private int maxWallBounces;
        private int wallBounces;
        private Rigidbody rb;

        public Vector3 Direction{
            get => direction;
            set => direction = value.normalized;
        }
        public float Speed{
            get => speed;
            set => speed = value;
        }

        private void Start(){
            rb = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate(){
            rb.velocity = Direction * speed;
        }

        public void ResetBounces(){
            wallBounces = 0;
        }

        public void Bounce(Vector3 normal){
            if(wallBounces >= maxWallBounces){
                Destroy(gameObject);
                return;
            }
            wallBounces ++;
            Direction = Vector3.Reflect(Direction, normal);
        }

    }
}
