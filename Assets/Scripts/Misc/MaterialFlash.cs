using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Echo.Misc{
    public sealed class MaterialFlash : MonoBehaviour{

        [SerializeField] private string propertyName;
        [ColorUsage(false, true)]
        [SerializeField] private Color color;
        [SerializeField] private float duration;

        private Material[] materials;

        private void Awake(){
            materials = GetComponentsInChildren<Renderer>().Select(r => r.material).ToArray();
        }

        public void Flash(){
            foreach(var mat in materials){
                mat.DOComplete();
                mat.DOColor(mat.GetColor(propertyName), propertyName, duration).From(color);
            }
        }

    }
}
