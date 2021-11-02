using UnityEngine;

namespace Echo{
    public interface IBullet{

        Vector3 Direction{ get; set; }
        float Speed{ get; set; }

    }
}
