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
        private readonly Subject<Unit> onNormalAttack = new Subject<Unit>();
        private readonly Subject<Unit> onSpecialAttack = new Subject<Unit>();

        public IObservable<Vector2> OnMove => move;
        public IObservable<Unit> OnInteract => onInteract;
        public IObservable<Unit> OnNormalAttack => onNormalAttack;
        public IObservable<Unit> OnSpecialAttack => onSpecialAttack;

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

        void GameInput.IGameplayActions.OnNormalAttack(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onNormalAttack.OnNext(Unit.Default);
            }
        }

        void GameInput.IGameplayActions.OnSpecialAttack(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onSpecialAttack.OnNext(Unit.Default);
            }
        }

    }
}
