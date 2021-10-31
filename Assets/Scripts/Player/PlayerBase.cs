using UnityEngine;

namespace Echo.Player{
    public class PlayerBase : MonoBehaviour{

        [SerializeField] private PlayerReflectBullet reflectBullet;

        void Start(){
            reflectBullet?.Init(this);
        }

        void Update(){
        }

    }
}
