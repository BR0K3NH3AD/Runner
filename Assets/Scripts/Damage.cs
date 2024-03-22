using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Damage : MonoBehaviour
    {
        private static PlayerHealth _playerHealth;

        private void OnTriggerEnter()
        {
            _playerHealth.DecreaseHealth();
        }        
        
        private void Awake()
        {
            if( _playerHealth == null ) _playerHealth = FindObjectOfType<PlayerHealth>();
        }
    }
}