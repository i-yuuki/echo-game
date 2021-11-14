using UnityEngine;
using UniRx;
using Echo.Extensions;
using Echo.Player;

namespace Echo.Enemy{
    public sealed class Bookmark : MonoBehaviour, IPlayerBulletAttackable, IReflectable
    {

        [SerializeField] private EnemyBase enemy;
        [SerializeField] private EnemySensePlayer enemySensePlayer;
        [SerializeField] private CollisionWithPlayer collisionWithPlayer;
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rb;

        private void Start(){
            enemySensePlayer.OnPlayerFound.Subscribe(player => {
                rb.velocity = (player.transform.position - transform.position).WithY(0).normalized * speed;
                transform.LookAt(player.transform.position);
            }).AddTo(this);
            collisionWithPlayer.OnPlayerCollide.Subscribe(player => {
                enemy.Die();
                player.Damage(1);
            }).AddTo(this);
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            enemy.Damage(1);
        }

        void IReflectable.OnReflect(PlayerBase player, ReflectType reflectType){
            enemy.Damage(1);
        }

        private void OnCollisionEnter(Collision collision){
            enemy.Die();
        }

    }
}
