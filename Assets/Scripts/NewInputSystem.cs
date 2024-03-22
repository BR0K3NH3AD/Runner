using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Runner
{
    public class NewInputSystem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private NewControls _player;

        [SerializeField] private bool _isJump;
        [SerializeField] private float _Speed;
        [SerializeField] private float _JumpSpeed;
        [SerializeField] private float _velocitySpeed = 1f;

        private void Awake()
        {
            _player = new NewControls();
        }

        private void OnEnable()
        {
            _player.Action.Enable();

            _player.Action.Jump.performed += OnJump;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var value = _player.Action.Movement.ReadValue<Vector2>();
            transform.position += new Vector3(value.x, 0f,  0f) * _Speed * Time.deltaTime;

            OnHeigthCheck();
        }

        private void FixedUpdate()
        {
            if (_rb == null) return;

            _rb.velocity += Vector3.forward * _velocitySpeed * 10f * Time.fixedDeltaTime;
        }

        private void OnJump(CallbackContext context)
        {
            if (_isJump != true) return;

            _rb.AddForce(Vector3.up * _JumpSpeed, ForceMode.Impulse);
            _rb.AddForce(Vector3.forward, ForceMode.VelocityChange);
        }

        private void OnHeigthCheck()
        {
            if (transform.position.y < -1)
            {
                Debug.Log("Смерть");
                UnityEditor.EditorApplication.isPaused = true;
            }
        }

        private void OnDisable()
        {
            _player.Action.Jump.performed -= OnJump;

            _player.Action.Disable();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _isJump = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            _isJump = false;
        }
    }

}

