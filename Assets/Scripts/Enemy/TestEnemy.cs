using UnityEngine;
using Echo.Player;

namespace Echo.Enemy{
    public class TestEnemy : MonoBehaviour, IPlayerDamageable{

        private uint health;
        [SerializeField] private uint maxHealth;

        private void Start(){
            health = maxHealth;
        }

        void IPlayerDamageable.Damage(uint damage){
            if(damage >= health){
                Die();
            }else{
                health -= damage;
            }
            Instantiate(LevelAssets.Instance.enemyDamage, transform.position, Quaternion.identity);
        }

        private void Die(){
            Destroy(gameObject);
        }

    }
}
