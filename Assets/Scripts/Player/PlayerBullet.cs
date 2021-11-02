using UnityEngine;

namespace Echo.Player{
    [RequireComponent(typeof(BulletBase))]
    public sealed class PlayerBullet : MonoBehaviour, IBullet, IReflectable{

        [SerializeField] private BulletBase bullet;

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

        private void Start(){
            Destroy(gameObject, 10);
        }

        private void OnCollisionEnter(Collision other){
            var attackable = other.gameObject.GetComponent<IPlayerBulletAttackable>();
            if(attackable != null){
                bullet.ResetBounces();
                attackable.OnPlayerBulletHit(this);
            }
            bullet.Bounce(other.contacts[0].normal);
        }

        void IReflectable.OnReflect(PlayerBase player){
            player.ReflectBullet(bullet);
        }

    }
}
