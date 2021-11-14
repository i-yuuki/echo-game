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

        private bool isAwake;
        private PlayerBase lastPlayerAttacked;

        private void Start(){
            isAwake = false;
            enemySensePlayer.OnPlayerFound.Subscribe(player => AttackTowards(player)).AddTo(this);
            enemySensePlayer.OnPlayerLost.Subscribe(player => AttackTowards(lastPlayerAttacked)).AddTo(this);
            collisionWithPlayer.OnPlayerCollide.Subscribe(player => {
                enemy.Die();
                player.Damage(1);
            }).AddTo(this);
        }

        private void AttackTowards(PlayerBase player){
            isAwake = true;
            lastPlayerAttacked = player;
            rb.velocity = (player.transform.position - transform.position).WithY(0).normalized * speed;
            transform.LookAt(player.transform.position);
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            enemy.Damage(1);
        }

        void IReflectable.OnReflect(PlayerBase player, ReflectType reflectType){
            enemy.Damage(1);
        }

        private void OnCollisionEnter(Collision collision){
            if(isAwake){
                AttackTowards(lastPlayerAttacked);
            }
        }

    }
}
