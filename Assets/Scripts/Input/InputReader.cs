using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

namespace Echo.Input{
    [CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObject/Game/Input Reader")]
    public sealed class InputReader : ScriptableObject, GameInput.IPlayerActions{

        private GameInput input;

        private readonly ReactiveProperty<Vector2> move = new ReactiveProperty<Vector2>(Vector2.zero);
        private readonly Subject<Unit> onInteract = new Subject<Unit>();
        private readonly Subject<Unit> onNormalAttack = new Subject<Unit>();
        private readonly Subject<Unit> onSpecialAttack = new Subject<Unit>();

        public IObservable<Vector2> OnMove => move;
        public IObservable<Unit> OnInteract => onInteract;
        public IObservable<Unit> OnNormalAttack => onNormalAttack;
        public IObservable<Unit> OnSpecialAttack => onSpecialAttack;

        private void OnEnable(){
            if(input == null){
                input = new GameInput();
                input.Player.SetCallbacks(this);
            }
            input.Enable();
        }

        private void OnDisable(){
            input.Disable();
        }

        void GameInput.IPlayerActions.OnInteract(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onInteract.OnNext(Unit.Default);
            }
        }

        void GameInput.IPlayerActions.OnMove(InputAction.CallbackContext ctx){
            move.Value = ctx.ReadValue<Vector2>();
        }

        void GameInput.IPlayerActions.OnNormalAttack(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onNormalAttack.OnNext(Unit.Default);
            }
        }

        void GameInput.IPlayerActions.OnSpecialAttack(InputAction.CallbackContext ctx){
            if(ctx.phase == InputActionPhase.Performed){
                onSpecialAttack.OnNext(Unit.Default);
            }
        }

    }
}
