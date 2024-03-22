using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private Transform[] _maps;

        private int _currentMapIndex = 0;

        private Vector3 _lastPosition = Vector3.zero;

        private void Awake()
        {
            _lastPosition = _maps[_maps.Length - 1].position;
        }

        public void ChangeMap()
        {
            _maps[_currentMapIndex].position = _lastPosition + new Vector3(0, 0, 9);
            _lastPosition = _maps[_currentMapIndex].transform.position;

            _currentMapIndex = (_currentMapIndex + 1) % _maps.Length;
        }
    }
}
