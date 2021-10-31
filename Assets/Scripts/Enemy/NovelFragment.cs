using System.Collections;
using UnityEngine;
using UniRx;
using Echo.Extensions;

namespace Echo.Enemy{
    public sealed class NovelFragment : MonoBehaviour
    {

        [SerializeField] private EnemyBase enemy;
        [SerializeField] private EnemySensePlayer enemySensePlayer;
        [SerializeField] private float attackInterval;
        [SerializeField] private float bulletSpeed;
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
                EnemyBullet bullet = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
                bullet.Shooter = transform;
                bullet.Direction = (playerPos - transform.position).WithY(0).normalized;
                bullet.Speed = bulletSpeed;
            }
        }

    }
}
