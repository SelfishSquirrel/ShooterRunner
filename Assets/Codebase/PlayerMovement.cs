using UnityEngine;

namespace Codebase
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Camera _playerCamera; // Камера игрока
        [SerializeField] private float _mouseSensitivity = 100f; // Чувствительность мыши
        [SerializeField] private float _gravity = -9.81f; // Гравитация
        [SerializeField] private float _jumpForce = 3f; // Сила прыжка
        [SerializeField] private float _playerSpeed = 5f; // Скорость движения

        private Vector3 _velocity; // Для гравитации и прыжка
        private float _xRotation = 0f; // Для поворота камеры по оси X

        public void Init(float playerSpeed, float jumpForce)
        {
            _playerSpeed = playerSpeed;
            _jumpForce = jumpForce;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            HandleMovement();
            HandleJump();
            HandleRotation();
        }

        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;


            transform.Rotate(Vector3.up * mouseX);

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            _playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }

        private void HandleJump()
        {
            if (_controller.isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
            {
                _velocity.y = _jumpForce;
            }

            _velocity.y += _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void HandleMovement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            move = move.normalized * _playerSpeed;
            _controller.Move(move * Time.deltaTime);
        }
    }
}