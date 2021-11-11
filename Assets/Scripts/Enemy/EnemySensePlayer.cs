using System;
using UnityEngine;
using UniRx;
using Echo.Player;

namespace Echo.Enemy{
    public sealed class EnemySensePlayer : MonoBehaviour
    {
        
        private PlayerBase playerNearby;

        private readonly Subject<PlayerBase> onPlayerFound = new Subject<PlayerBase>();
        private readonly Subject<Unit> onPlayerLost = new Subject<Unit>();

        public PlayerBase PlayerNearby => playerNearby;
        public IObservable<PlayerBase> OnPlayerFound => onPlayerFound;
        public IObservable<Unit> OnPlayerLost => onPlayerLost;

        private void OnTriggerEnter(Collider other){
            var player = other.GetComponent<PlayerBase>();
            if(!player || player == playerNearby) return;
            playerNearby = player;
            onPlayerFound.OnNext(player);
        }

        private void OnTriggerExit(Collider other){
            var player = other.GetComponent<PlayerBase>();
            if(!player || player != playerNearby) return;
            playerNearby = null;
            onPlayerLost.OnNext(Unit.Default);
        }

    }
}
