﻿using System;
using UnityEngine;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using Echo.Save;

namespace Echo.Misc{
    public sealed class PrologueScene : MonoBehaviour{

        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private float delay;
        [SerializeField] private string nextScene;
        [SerializeField] private VideoPlayer video;

        private void Start(){
            PlayAsync().Forget();
        }

        private async UniTaskVoid PlayAsync(){
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            video.loopPointReached += _ => {
                GameManager.Instance.LoadScene(nextScene);
            };
            video.Play();
        }

    }
}
