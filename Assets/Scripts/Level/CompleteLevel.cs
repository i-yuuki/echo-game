using System;
using UnityEngine;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Audio;
using Echo.Input;
using Echo.UI;

namespace Echo.Level{
    public sealed class CompleteLevel : MonoBehaviour{

        [SerializeField] private InputReader inputReader;
        [SerializeField] private AudioCue se;
        [SerializeField] private AudioChannel channel;
        [SerializeField] private float slowmoDuration;
        [SerializeField] private RoomEnemies enemies;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private LevelCompleteDisplay display;
        [SerializeField] private string nextScene; // ここでいいのか？

        private void Start(){
            enemies.OnAllEnemiesDied.Subscribe(_ => {
                inputReader.EnableMenuInput();
                Display().Forget();
                if(se && channel){
                    channel.Request(se);
                }
            }).AddTo(this);
        }

        private async UniTaskVoid Display(){
            Time.timeScale = 0.5f;
            await UniTask.Delay(TimeSpan.FromSeconds(slowmoDuration), ignoreTimeScale: true);
            Time.timeScale = 1;
            virtualCamera.gameObject.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            display.Show(nextScene);
        }

    }
}
