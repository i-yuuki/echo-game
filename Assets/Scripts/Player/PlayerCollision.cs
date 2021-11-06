using UnityEngine;

namespace Echo.Player{
    public sealed class PlayerCollision : MonoBehaviour{

        [SerializeField] private PlayerBase player;

        // プレイヤーがCharacterControllerな都合上
        // プレイヤーが移動している間は弾側のOnCollisionEnterが呼ばれないことがあり
        // OnControllerColliderHitを使う必要がある
        private void OnControllerColliderHit(ControllerColliderHit hit){
            if(hit.gameObject.activeSelf && hit.gameObject.TryGetComponent<BulletBase>(out var bullet)){
                // GORIOSHI POINT
                // CharacterController.Move 1回で複数回同じ弾が反応することがあるので
                // activeを使って1回だけダメージ受けるように
                // Destroy+nullチェックは効かなかった
                bullet.gameObject.SetActive(false);
                Destroy(bullet.gameObject);
                player.Damage(1);
            }
        }

    }
}
