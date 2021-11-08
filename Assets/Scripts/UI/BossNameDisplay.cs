using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using Echo.Level;

namespace Echo.UI{
    public sealed class BossNameDisplay : MonoBehaviour{

        private const string ShaderProperty = "_Intensity";

        [SerializeField] private float fadeDuration;
        [SerializeField] private float displayDuration;
        [SerializeField] private float glitchIntensity;
        [SerializeField] private Room room;
        [SerializeField] private Image image;

        private void Awake(){
            room.OnEnter.Subscribe(_ => Display()).AddTo(this);
        }

        public void Display(){
            DisplayAsync().Forget();
        }

        public async UniTaskVoid DisplayAsync(){
            image.gameObject.SetActive(true);
            await image.DOFade(1, fadeDuration).From(0);

            image.material.SetFloat(ShaderProperty, glitchIntensity);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            image.material.SetFloat(ShaderProperty, 0);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));

            image.material.SetFloat(ShaderProperty, glitchIntensity);
            await UniTask.Delay(TimeSpan.FromSeconds(0.15f));

            image.material.SetFloat(ShaderProperty, 0);
            await UniTask.Delay(TimeSpan.FromSeconds(displayDuration));

            await image.DOFade(0, fadeDuration);
            image.gameObject.SetActive(false);
        }

    }
}
