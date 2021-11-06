using System;
using System.Linq;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Enemy;

namespace Echo.Level{
    public sealed class RoomEnemies : MonoBehaviour{

        [SerializeField] private EnemyBase[] enemies;
        [SerializeField] private EnemyBase[] bosses;
        [SerializeField] private bool destroyEnemiesOnBossDeath;

        private readonly Subject<Unit> onAllEnemiesDied = new Subject<Unit>();

        public IObservable<Unit> OnAllEnemiesDied => onAllEnemiesDied;

        private void Start(){
            Run().Forget();
        }

        public void ActivateAll(){
            foreach(var enemy in enemies){
                enemy.gameObject.SetActive(true);
            }
            foreach(var boss in bosses){
                boss.gameObject.SetActive(true);
            }
        }

        // 【募】いい名前
        private async UniTaskVoid Run(){
            if(bosses.Length > 0){
                await EnemiesDeath(bosses);
                if(destroyEnemiesOnBossDeath){
                    foreach(var enemy in enemies){
                        if(enemy){
                            Destroy(enemy.gameObject);
                        }
                    }
                }else{
                    await EnemiesDeath(enemies);
                }
            }else{
                await EnemiesDeath(enemies);
            }
            onAllEnemiesDied.OnNext(Unit.Default);
        }

        private async UniTask EnemiesDeath(EnemyBase[] enemies){
            await enemies.Where(enemy => enemy).Select(enemy => {
                var tcs = AutoResetUniTaskCompletionSource.Create();
                enemy.OnDeath.Subscribe(_ => tcs.TrySetResult());
                return tcs.Task;
            });
        }

    }
}
