using System.Collections;
using UnityEngine;
using UniRx;
using Echo.Enemy;
using Echo.Player;

namespace Echo.Boss{
    public class TheCrowd : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private EnemyBase enemy;
        [SerializeField] private EnemySensePlayer enemySensePlayer;
        [SerializeField] private float attackInterval;
        [SerializeField] private float attackRadius;
        [SerializeField] private Animator animator;

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
                animator.SetTrigger("Attack");
            }
        }

        // Animation Event から呼ばれる
        public void Attack(){
            foreach(Collider collider in Physics.OverlapSphere(transform.position, attackRadius)){
                var player = collider.GetComponent<PlayerBase>();
                if(!player) continue;
                player.Damage(1);
            }
        }
        
        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            enemy.Damage(1);
            animator.SetTrigger("Damage");
        }

    }
}
