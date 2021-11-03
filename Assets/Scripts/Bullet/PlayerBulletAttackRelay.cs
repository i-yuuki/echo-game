using UnityEngine;
using Echo.Enemy;
using Echo.Player;

namespace Echo.Bullet{
    public sealed class PlayerBulletAttackRelay : MonoBehaviour, IPlayerBulletAttackable{

        [SerializeField] private Component target;

        // GameObjectをドロップできるようにする
        private void OnValidate(){
            if(!target || target is IPlayerBulletAttackable) return;
            if(target.TryGetComponent<IPlayerBulletAttackable>(out var attackable)){
                target = attackable as Component;
            }else{
                target = null;
                Debug.LogWarning("The component must be IPlayerBulletAttackable");
            }
        }

        void IPlayerBulletAttackable.OnPlayerBulletHit(PlayerBullet bullet){
            (target as IPlayerBulletAttackable).OnPlayerBulletHit(bullet);
        }

    }
}
