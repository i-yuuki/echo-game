using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Echo.Player{
    public class PlayerBullet : MonoBehaviour{

        private Vector3 direction;
        public float speed = 1;
        public int chargeLevel;
        public int maxWallBounces;
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
        public int Damage => 1;

        void Start(){
            rb = GetComponentInChildren<Rigidbody>();
            wallBounces = 0;
            Destroy(gameObject, 10);
        }

        private void FixedUpdate(){
            rb.velocity = Direction * speed;
        }

        private void OnCollisionEnter(Collision other){
            var attackable = other.gameObject.GetComponent<IPlayerBulletAttackable>();
            if(attackable == null){
                if(wallBounces >= maxWallBounces){
                    Destroy(gameObject);
                    return;
                }
                wallBounces ++;
            }else{
                wallBounces = 0;
                attackable.OnPlayerBulletHit(this);
            }
            Direction = Vector3.Reflect(Direction, other.contacts[0].normal);
        }

}
}
