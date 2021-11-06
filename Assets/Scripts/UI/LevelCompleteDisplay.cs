using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Echo.UI{
    public sealed class LevelCompleteDisplay : MonoBehaviour{

        [SerializeField] private CanvasGroup container;
        [SerializeField] private Button buttonNextLevel;
        [SerializeField] private Button buttonLevelSelect;

        private void Start(){
            buttonLevelSelect.onClick.AddListener(() => GameManager.Instance.LoadScene("LevelSelect"));
        }

        public void Show(string nextScene){
            ShowAsync(nextScene).Forget();
        }

        public async UniTask ShowAsync(string nextScene){
            bool hasNextScene = !string.IsNullOrEmpty(nextScene);
            buttonNextLevel.gameObject.SetActive(hasNextScene);
            gameObject.SetActive(true);
            await container.DOFade(1, 0.3f).From(0);
            buttonNextLevel.onClick.RemoveAllListeners();
            if(hasNextScene){
                buttonNextLevel.onClick.AddListener(() => GameManager.Instance.LoadScene(nextScene));
                EventSystem.current.SetSelectedGameObject(buttonNextLevel.gameObject);
            }else{
                EventSystem.current.SetSelectedGameObject(buttonLevelSelect.gameObject);
            }
        }

    }
}
