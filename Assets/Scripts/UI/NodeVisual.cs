using System;
using UnityEngine;

namespace UI
{
    public class NodeVisual : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;

        private GameObject _currentVisual;
        private int _level;

        public void TryUpdate(int level)
        {
            if (_level != level)
            {
                _level = level;

                _currentVisual?.SetActive(false);
                _currentVisual = levels[_level - 1];
                _currentVisual.SetActive(true);
            }
        }
    }
}