using System;
using UnityEngine;

namespace UI
{
    public class NodeVisual : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;
        [SerializeField] private MeshRenderer selectedRenderer;
        [SerializeField] private ParticleSystem upgrade;

        private GameObject _currentVisual;
        private int _level;

        private void Awake()
        {
            upgrade.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        public void TryChangeLevel(int level)
        {
            if (_level != level)
            {
                _level = level;

                _currentVisual?.SetActive(false);
                _currentVisual = levels[_level - 1];
                _currentVisual.SetActive(true);
            }
        }

        public void TrySelect(bool selected)
        {
            if (selected)
            {
                selectedRenderer.gameObject.SetActive(true);
                selectedRenderer.material.color = Color.green;
            }
            else
            {
                selectedRenderer.gameObject.SetActive(false);
            }
        }
        
        public void TryStartUpgradeParticles(bool upgradeInProgress) {
            if (upgradeInProgress)
            {
                if (upgrade.isPlaying)
                    return;
                
                upgrade.Play(true);
            }
            else
            {
                if (upgrade.isPlaying)
                    upgrade.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }
}