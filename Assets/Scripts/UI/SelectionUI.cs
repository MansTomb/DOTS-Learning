using System;
using Unity.Entities;
using Unity.Physics.Systems;
using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    private bool isSelecting;
    private bool _leftButtonHolding;

    private Vector3 _startHoldPosition;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _leftButtonHolding = true;
            _startHoldPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _leftButtonHolding = false;
            isSelecting = false;
        }

        if (_leftButtonHolding)
        {
        }

        if (_leftButtonHolding)
        {
            isSelecting = true;
        }
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            var rect = Utils.GetScreenRect(_startHoldPosition, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.2f, 0.8f, 0.2f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 1, new Color(0.2f, 0.8f, 0.2f));
        }
    }
}