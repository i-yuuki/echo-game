using System.Collections;
using UnityEngine;
using UniRx;
using Echo.Extensions;
using Echo.Player;

namespace Echo.Enemy{
    public sealed class NovelFragment : MonoBehaviour, IPlayerBulletAttackable
    {

        [SerializeField] private EnemyBase enemy;
        [SerializeField] private EnemySensePlayer enemySensePlayer;
        [SerializeField] private float attackInterval;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float shootPositionRadius;
        [SerializeField] private Transform shootPosition;

        [SerializeField] private Animator animator;
        [SerializeField] private EnemyBullet bulletPrefab;

        private void Start(){
            enemySensePlayer.OnPlayerFound.Subscribe(_ => SetEnemyAwake(true)).AddTo(this);
            enemySensePlayer.OnPlayerLost.Subscribe(_ => SetEnemyAwake(false)).AddTo(this);
        }

        private void SetEnemyAwake(bool awake){
            Debug.Log(awake);
            animator.SetBool("Awake", awake);
            StopCoroutine("ShootLoop");
            if(awake){
                StartCoroutine("ShootLoop");
            }
        }

        private IEnumerator ShootLoop(){
            while(true){
                yield return new WaitForSeconds(attackInterval);
                var playerPos = enemySensePlayer.PlayerNearby.transform.position;
                var direction = (playerPos - transform.position).WithY(0).normalized;
                EnemyBullet bullet = Instantiate(bulletPrefab, shootPosition.position + (direction * shootPositionRadius), Quaternion.identity);
                bullet.Shooter = transform;
                bullet.Direction = direction;
                bullet.Speed = bulletSpeed;
            }
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            enemy.Damage(1);
        }

    }
}
