using UnityEngine;
using Echo.Extensions;

namespace Echo.Player{
    [RequireComponent(typeof(BulletBase))]
    public sealed class PlayerBullet : MonoBehaviour, IBullet, IReflectable{

        [SerializeField] private BulletBase bullet;
        [SerializeField] private bool isPiercing;

        public Vector3 Direction{
            get => bullet.Direction;
            set => bullet.Direction = value;
        }
        public float Speed{
            get => bullet.Speed;
            set => bullet.Speed = value;
        }
        public bool IsPiercing => isPiercing;

        private void Reset(){
            bullet = GetComponent<BulletBase>();
        }

        private void Start(){
            Destroy(gameObject, 10);
        }

        private void OnCollisionEnter(Collision other){
            if(!isPiercing){
                HitIfAttackable(other.gameObject);
            }
            bullet.Bounce(other.contacts[0].normal);
        }

        private void OnTriggerEnter(Collider other){
            if(isPiercing){
                HitIfAttackable(other.gameObject);
            }
        }

        private void HitIfAttackable(GameObject obj){
            var attackable = obj.GetComponent<IPlayerBulletAttackable>();
            if(attackable != null){
                bullet.ResetBounces();
                attackable.OnPlayerBulletHit(this);
            }
        }

        void IReflectable.OnReflect(PlayerBase player){
            player.ReflectBullet(bullet);
        }

    }
}
