using System.Collections;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Echo.Enemy;
using Echo.Extensions;
using Echo.Player;

namespace Echo.Boss{
    public sealed class TheCrowd : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private EnemyBase enemy;
        [SerializeField] private EnemySensePlayer enemySensePlayer;
        [SerializeField] private float attackInterval;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private Transform[] shootPositions;
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyBullet bulletPrefab;

        private void Start(){
            enemySensePlayer.OnPlayerFound.Subscribe(_ => SetEnemyAwake(true)).AddTo(this);
            enemySensePlayer.OnPlayerLost.Subscribe(_ => SetEnemyAwake(false)).AddTo(this);
        }

        private void SetEnemyAwake(bool awake){
            StopCoroutine("AttackLoop");
            if(awake){
                StartCoroutine("AttackLoop");
            }
        }

        private IEnumerator AttackLoop(){
            while(true){
                yield return new WaitForSeconds(attackInterval);
                transform.DODynamicLookAt(enemySensePlayer.PlayerNearby.transform.position.WithY(transform.position.y), 0.5f);
                animator.SetTrigger("Attack");
            }
        }

        // Animation Event から呼ばれる
        public void Attack(){
            var playerPos = enemySensePlayer.PlayerNearby.transform.position;
            foreach(var shootPos in shootPositions){
                var direction = (playerPos - shootPos.position).WithY(0);
                var bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
                bullet.Shooter = transform;
                bullet.Direction = direction;
                bullet.Speed = bulletSpeed;
            }
        }
        
        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            enemy.Damage(1);
            animator.SetTrigger("Damage");
        }

    }
}
