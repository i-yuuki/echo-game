using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

namespace Echo.Input{
    [CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObject/Game/Input Reader")]
    public sealed class InputReader : ScriptableObject, GameInput.IGameplayActions{

        private GameInput input;

        private readonly ReactiveProperty<Vector2> move = new ReactiveProperty<Vector2>(Vector2.zero);
        private readonly Subject<Unit> onInteract = new Subject<Unit>();
        private readonly Subject<Unit> onReflect = new Subject<Unit>();
        private readonly Subject<Unit> onSlowmo = new Subject<Unit>();

        public IObservable<Vector2> OnMove => move;
        public IObservable<Unit> OnInteract => onInteract;
        public IObservable<Unit> OnReflect => onReflect;
        public IObservable<Unit> OnSlowmo => onSlowmo;

        public void EnableGameplayInput(){
            input.Gameplay.Enable();
        }

        public void EnableMenuInput(){
            input.Gameplay.Disable();
        }

        private void OnEnable(){
            if(input == null){
                input = new GameInput();
                input.Gameplay.SetCallbacks(this);
            }
            EnableGameplayInput();
        }

        private void OnDisable(){
            input.Disable();
        }

        void GameInput.IGameplayActions.OnInteract(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onInteract.OnNext(Unit.Default);
            }
        }

        void GameInput.IGameplayActions.OnMove(InputAction.CallbackContext ctx){
            move.Value = ctx.ReadValue<Vector2>();
        }

        void GameInput.IGameplayActions.OnReflect(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onReflect.OnNext(Unit.Default);
            }
        }

        void GameInput.IGameplayActions.OnSlowmo(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onSlowmo.OnNext(Unit.Default);
            }
        }

    }
}
