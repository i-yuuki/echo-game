using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Echo.UI.LevelSelect{
    public sealed class LevelSelectLevel : MonoBehaviour{

        [SerializeField] private bool isSelectable;
        [SerializeField] private string sceneName;
        [SerializeField] private CanvasGroup container;

        public bool IsSelectable => isSelectable;
        public string SceneName => sceneName;

        public void Show(){
            container.gameObject.SetActive(true);
            container.DOFade(1, 0.3f).From(0);
        }

        public void Hide(){
            container.gameObject.SetActive(false);
        }

    }
}
