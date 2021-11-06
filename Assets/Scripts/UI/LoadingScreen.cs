using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Echo.UI{
    public sealed class LoadingScreen : MonoBehaviour{

        [SerializeField] private CanvasGroup group;
        [SerializeField] private Slider progressBar;
        [SerializeField] private VideoPlayer video;
        private bool isVisible = false;

        public bool IsVisible => isVisible;
        public float Progress{
            set{
                if(progressBar){
                    progressBar.value = value;
                }
            }
        }

        public void PrepareVideo(){
            video.Prepare();
        }

        public async UniTask ShowAsync(){
            video.Play();
            gameObject.SetActive(true);
            await group.DOFade(1, 0.2f).From(0);
        }

        public async UniTask HideAsync(){
            await group.DOFade(0, 0.2f).From(1);
            gameObject.SetActive(false);
            video.Pause();
        }

    }
}
