using System;
using UnityEngine;
using UniRx;
using Echo.Player;

namespace Echo{
    public class CollisionWithPlayer : MonoBehaviour{

        private readonly Subject<PlayerBase> onPlayerCollide = new Subject<PlayerBase>();

        public IObservable<PlayerBase> OnPlayerCollide => onPlayerCollide;

        private void OnCollisionEnter(Collision collision){
            if(collision.gameObject.TryGetComponent<PlayerBase>(out var player)){
                onPlayerCollide.OnNext(player);
            }
        }

        public void FireCollision(PlayerBase player){
            onPlayerCollide.OnNext(player);
        }

    }
}
