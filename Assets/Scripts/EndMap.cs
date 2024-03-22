using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class EndMap: MonoBehaviour
    {
        private static MapGenerator _mapGenerator;

        private void Awake()
        {
            if(_mapGenerator == null) _mapGenerator = FindObjectOfType<MapGenerator>();
        }

        private void OnTriggerEnter()
        {
            _mapGenerator.ChangeMap();
        }
    }
}