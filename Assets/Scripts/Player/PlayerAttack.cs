using UnityEngine;

namespace Echo.Player{
    public class PlayerAttack : MonoBehaviour{

        private GameInput inputActions;

        private void Awake(){
            inputActions = new GameInput();
            inputActions.Player.NormalAttack.performed += ctx => NormalAttack();
        }

        private void OnEnable(){
            inputActions.Enable();
        }

        private void OnDisable(){
            inputActions.Disable();
        }

        private void NormalAttack(){
            var collisions = Physics.OverlapSphere(transform.position, 1);
            foreach(var collision in collisions){
                if(collision.TryGetComponent<IPlayerDamageable>(out var damageable)){
                    damageable.Damage(1);
                }
            }
        }

    }
}
