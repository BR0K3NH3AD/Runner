using TMPro;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreText : MonoBehaviour
    {
        private ScoreChanger _scoreChanger;
        private TMP_Text _tmpText;

        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _scoreChanger = FindObjectOfType<ScoreChanger>();
            _scoreChanger.ScoreChanged += OnScoreIncrease;
            OnScoreIncrease();
        }

        private void OnScoreIncrease()
        {
            _tmpText.text = _scoreChanger.Score.ToString();
        }
    }
}
