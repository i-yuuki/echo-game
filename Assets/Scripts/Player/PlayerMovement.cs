using UnityEngine;

namespace Echo.Player{
    public class PlayerMovement : MonoBehaviour{

        [SerializeField] private float walkSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        private GameInput inputActions;
        private Vector3 velocity;
        private Quaternion targetRotation;
        private new Camera camera;

        private void Awake(){
            inputActions = new GameInput();
        }

        private void OnEnable(){
            inputActions.Enable();
        }

        private void OnDisable(){
            inputActions.Disable();
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
            var input = inputActions.Player.Move.ReadValue<Vector2>();
            var movement = right.normalized * input.x + forward.normalized * input.y;
            characterController.Move(movement * walkSpeed * Time.deltaTime);

            animator.SetFloat("Walk", input.magnitude);

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
