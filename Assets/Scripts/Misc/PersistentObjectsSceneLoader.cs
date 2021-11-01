using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjectsSceneLoader{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadPersistentObjectsScene(){
        if(!SceneManager.GetSceneByName("PersistentObjects").IsValid()){
            SceneManager.LoadScene("PersistentObjects", LoadSceneMode.Additive);
        }
    }
    
}
