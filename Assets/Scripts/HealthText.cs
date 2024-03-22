using TMPro;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(TMP_Text))]
    public class HealthText : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private TMP_Text _tmpText;

        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            _playerHealth.HealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnHealthChanged()
        {
            _tmpText.text = _playerHealth.Health.ToString();
        }
    }
}