using UnityEngine;
using UniRx;
using Echo.Input;

namespace Echo.Player{
    public class PlayerMovement : MonoBehaviour{

        [SerializeField] private float walkSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        private Vector2 movementInput;
        private Vector3 movement;
        private Vector3 velocity;
        private Quaternion targetRotation;
        private new Camera camera;

        public Vector3 Movement => movement;

        private void Awake(){
            inputReader.OnMove.Subscribe(movement => movementInput = movement).AddTo(this);
        }

        void Start(){
            velocity = Vector3.zero;
            targetRotation = transform.rotation;
            camera = Camera.main;
        }

        void Update(){
            Vector3 forward = camera.transform.forward;
            Vector3 right   = camera.transform.right;
            forward.y = 0;
            right.y = 0;
            movement = right.normalized * movementInput.x + forward.normalized * movementInput.y;
            characterController.Move(movement * walkSpeed * Time.deltaTime);

            animator.SetFloat("Walk", movementInput.magnitude);

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
            if(characterController.isGrounded){
                velocity.y = 0;
            }

            if(movement.sqrMagnitude > 0){
                targetRotation = Quaternion.LookRotation(movement);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }
}
