using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Runner
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField,Range(1, 5)] private int _health;

        public int Health => _health;
        public event Action HealthChanged;

        public void DecreaseHealth()
        {
            _health--;

            HealthChanged?.Invoke();

            if (_health == 0)
            {
                Debug.Log("Смерть");
                UnityEditor.EditorApplication.isPaused = true;
            }
        }
    }

}
