using UnityEngine;
using UnityEngine.UI;

namespace Echo.UI{
    public sealed class LoadingScreen : MonoBehaviour{

        [SerializeField] private CanvasGroup group;
        [SerializeField] private Slider progressBar;
        private bool isVisible = false;

        public bool IsVisible => isVisible;
        public float Progress{
            set => progressBar.value = value;
        }

        public void Show(){
            gameObject.SetActive(true);
        }

        public void Hide(){
            gameObject.SetActive(false);
        }

    }
}
