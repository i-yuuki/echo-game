using UnityEngine;
using UnityEngine.UI;

namespace Echo.Scene.LevelSelect{
    public sealed class LevelSelectScene : MonoBehaviour{

        [SerializeField] private Button buttonConfirm;

        private void Start(){
            buttonConfirm.onClick.AddListener(() => GameManager.Instance.LoadScene("Level1"));
        }

    }
}
