using System;
using UnityEngine;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.UI;

namespace Echo.Level{
    public sealed class CompleteLevel : MonoBehaviour{

        [SerializeField] private float slowmoDuration;
        [SerializeField] private RoomEnemies enemies;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private LevelCompleteDisplay display;

        private void Start(){
            enemies.OnAllEnemiesDied.Subscribe(_ => Display().Forget()).AddTo(this);
        }

        private async UniTaskVoid Display(){
            // TODO disable gameplay input
            Time.timeScale = 0.5f;
            await UniTask.Delay(TimeSpan.FromSeconds(slowmoDuration), ignoreTimeScale: true);
            Time.timeScale = 1;
            virtualCamera.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            display.Show();
        }

    }
}
