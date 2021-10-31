using UnityEngine;

namespace Echo{
    public class LevelAssets : MonoBehaviour{

        public static LevelAssets Instance{ get; private set; }

        [Header("Prefabs")]
        public GameObject enemyDamage;

        private void Awake(){
            if(Instance){
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void OnDestroy(){
            if(Instance == this){
                Instance = null;
            }
        }

    }
}
