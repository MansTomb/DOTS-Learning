using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class NodeUI : MonoBehaviour
    {
        public TMP_Text text;
        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            transform.forward = -_cam.transform.position.normalized;
        }
    }
}