using System.Linq;
using UnityEngine;

public sealed class AutoDestroyParticle : MonoBehaviour{

    ParticleSystem[] particles;

    void Start(){
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    void Update(){
        if(particles.All(particle => !particle.IsAlive())){
            Destroy(gameObject);
        }
    }
}
