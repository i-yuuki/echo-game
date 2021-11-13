using UnityEngine;
using UniRx;
using Echo.Audio;

namespace Echo.Level{
    public sealed class RoomBGM : MonoBehaviour{

        [SerializeField] private AudioCue bgm;
        [SerializeField] private AudioChannel channel;
        [SerializeField] private Room room;
        [SerializeField] private bool stopOnComplete;

        private void Start(){
            room.OnEnter.Subscribe(_ => channel.Request(bgm)).AddTo(this);
            if(stopOnComplete){
                room.OnComplete.Subscribe(_ => channel.RequestStop()).AddTo(this);
            }
        }

    }
}
