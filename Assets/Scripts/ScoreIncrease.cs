using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class ScoreIncrease : MonoBehaviour
    {
        private static ScoreChanger _scoreChanger;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                _scoreChanger.ScoreIncrease();
                //Debug.Log("—чет")
            }
        }

        private void Awake()
        {
            if (_scoreChanger == null) _scoreChanger = FindObjectOfType<ScoreChanger>();
        }
    }

}
