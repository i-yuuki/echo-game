using System;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Echo.Audio;
using Echo.Input;

namespace Echo.Player{
    [RequireComponent(typeof(PlayerBase))]
    public sealed class PlayerReflectBullet : MonoBehaviour{
        
        [SerializeField] private PlayerBase player;
        [SerializeField] private float ringRadius;
        [SerializeField] private float ringWidth;
        [SerializeField] private int ringWidthLevel;
        [SerializeField] private float ringWidthPerLevel;
        [SerializeField] private float bulletAcceleration;
        [Range(0, 1)]
        [SerializeField] private float playerMovementRatio;
        [SerializeField] private float cooldownDuration;
        [SerializeField] private float slowmoCharge;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerBullet prefabBullet;
        [SerializeField] private PlayerBullet prefabPiercingBullet;
        [SerializeField] private Animator animator;
        [SerializeField] private ParticleSystem reflectEffect;
        [SerializeField] private AudioCue se;
        [SerializeField] private AudioChannel seChannel;

        private readonly ReactiveProperty<ReflectType> type = new ReactiveProperty<ReflectType>();
        private float cooldownTime;

        public ReflectType ReflectType{
            get => type.Value;
            set => type.Value = value;
        }
        public int RingWidthLevel{
            get => ringWidthLevel;
            set => ringWidthLevel = value;
        }

        public IObservable<ReflectType> OnReflectTypeChange => type;

        private void Reset(){
            player = GetComponent<PlayerBase>();
        }

        private void Awake(){
            inputReader.OnReflect.Subscribe(_  => ReflectBullets()).AddTo(this);
        }

        private void Update(){
            if(cooldownTime > 0){
                cooldownTime = Mathf.Max(0, cooldownTime - Time.deltaTime);
            }
        }

        private void ReflectBullets(){
            if(!player) return;
            if(cooldownTime > 0) return;
            bool reflected = false;
            float radius = ringRadius + ringWidth / 2 + ringWidthLevel * ringWidthPerLevel;
            foreach(Collider collider in Physics.OverlapSphere(transform.position, radius)){
                IReflectable reflectable = collider.GetComponent<IReflectable>();
                if(!(reflectable is MonoBehaviour)) continue; // nullチェックも兼ねる
                var monoReflectable = reflectable as MonoBehaviour;
                reflectable.OnReflect(player, type.Value);
                reflected = true;
            }
            if(reflected){
                cooldownTime = cooldownDuration;
                seChannel.Request(se);
                animator.SetTrigger("Reflect");
                reflectEffect.time = 0;
                reflectEffect.Play();
            }
        }

        public void ToggleReflectType(){
            ReflectType = ReflectType == ReflectType.SPREADING ? ReflectType.PIERCING : ReflectType.SPREADING;
        }

        public void ReflectBullet(BulletBase bulletToReflect, ReflectType reflectType){
            PlayerBullet CreateBullet(PlayerBullet prefab){
                var bullet = Instantiate(prefab, bulletToReflect.transform.position, Quaternion.identity);
                var movement = player.Movement;
                if(movement.sqrMagnitude > 0){
                    bullet.Direction = Vector3.Lerp(-bulletToReflect.Direction, movement.normalized, playerMovementRatio);
                }else{
                    bullet.Direction = -bulletToReflect.Direction;
                }
                bullet.Speed = bulletToReflect.Speed + bulletAcceleration;
                var r = bullet.GetComponentInChildren<Renderer>();
                if(r){
                    var mat = r.material;
                    mat.DOComplete();
                    mat.DOColor(mat.GetColor("_EmissionColor"), "_EmissionColor", 0.3f).From(new Color(2, 2, 2, 1));
                }
                return bullet;
            }
            Destroy(bulletToReflect.gameObject);
            switch(reflectType){
                case ReflectType.NORMAL:
                    CreateBullet(prefabBullet);
                    break;
                case ReflectType.SPREADING:
                    for(int i = 0;i < player.Level + 1;i ++){
                        var bullet = CreateBullet(prefabBullet);
                        bullet.Direction = Quaternion.AngleAxis((i - player.Level / 2.0f) * 10, Vector3.up) * bullet.Direction;
                    }
                    break;
                case ReflectType.PIERCING:
                {
                    var bullet = CreateBullet(prefabPiercingBullet);
                    float scale = 1 + (player.Level - 1) / 2.0f;
                    bullet.transform.localScale = new Vector3(scale, scale, scale);
                    break;
                }
                default:
                    throw new NotImplementedException($"Reflect type {reflectType} not implemented");
            };
            player.ChargeSlowmo(slowmoCharge);
        }

    }
}
