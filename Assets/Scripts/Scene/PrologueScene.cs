using UnityEngine;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using Echo.Save;

namespace Echo.Misc{
    public sealed class PrologueScene : MonoBehaviour{

        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private string nextScene;
        [SerializeField] private VideoPlayer video;

        private void Start(){
            if(saveSystem.SaveData.playCount == 1){
                video.Play();
                video.loopPointReached += _ => {
                    GameManager.Instance.LoadScene(nextScene);
                };
            }else{
                GameManager.Instance.LoadScene(nextScene);
            }
        }

    }
}
