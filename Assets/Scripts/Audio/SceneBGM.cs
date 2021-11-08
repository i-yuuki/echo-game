﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Echo.Audio{
    public sealed class SceneBGM : MonoBehaviour{

        [SerializeField] private AudioCue bgm;
        [SerializeField] private AudioChannel channel;
        [SerializeField] private bool stopOnDestroy;

        private void Start(){
            channel.Request(bgm);
        }

        private void OnDestroy(){
            if(stopOnDestroy){
                channel.RequestStop();
            }
        }

    }
}
