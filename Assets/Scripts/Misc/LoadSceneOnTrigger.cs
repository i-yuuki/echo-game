using UnityEngine;
using UnityEngine.SceneManagement;

namespace Echo.Misc{
    public sealed class LoadSceneOnTrigger : MonoBehaviour{

        [SerializeField] private string sceneName;

        private void OnTriggerEnter(Collider other){
            if(other.CompareTag("Player")){
                SceneManager.LoadScene(sceneName);
            }
        }

    }
}
