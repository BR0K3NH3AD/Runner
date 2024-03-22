using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class ScoreChanger : MonoBehaviour
    {
        private int _score = 0;

        public int Score => _score;
        public event Action ScoreChanged;

        public void ScoreIncrease()
        {
            _score += 100;
            ScoreChanged?.Invoke();
        }
    }
}