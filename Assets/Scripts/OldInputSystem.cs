using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner
{
    public class OldInputSystem : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _rotateSpeed = 5f;

        [SerializeField] private Rigidbody _rb;

        [SerializeField] private bool _isJump;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            MoveLeft();
            MoveRight();
            HeigthCheck();
            MoveForward();
            Jump();
        }

        /*private void FixedUpdate()
        {
            HeigthCheck();
            MoveForward();
            Jump();
        }*/

        private void MoveForward()
        {
            _rb.velocity += _speed * Vector3.forward * Time.fixedDeltaTime;
        }

        private void MoveLeft()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rb.transform.position += new Vector3(-_rotateSpeed, 0f, 0f) * Time.deltaTime;
            }
        }

        private void MoveRight()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _rb.transform.position += new Vector3(_rotateSpeed, 0f, 0f) * Time.deltaTime;
            }
        }

        private void Jump()
        {
            if (_isJump != true) return;
            if (Input.GetKeyDown (KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }

        }

        private void HeigthCheck()
        {
            if (transform.position.y < -1)
            {
                Debug.Log("Смерть");
                UnityEditor.EditorApplication.isPaused = true;
            }
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
