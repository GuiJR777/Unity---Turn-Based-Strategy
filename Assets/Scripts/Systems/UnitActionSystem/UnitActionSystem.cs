using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private PlayerUnit _playerUnitSelected;
    [SerializeField] private LayerMask _unitLayerMask;

    private bool _hasAUnitInMousePosition;

    // MonoBehaviour Methods
    private void Awake()
    {
        _playerUnitSelected.SetSelected(true);
    }

    private void Update()
    {
        InputHandler();
    }

    // Input Methods
    private void InputHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseButtonDown();
        }
    }

    private void OnLeftMouseButtonDown()
    {
        PlayerUnit newSelectedUnit = GetPlayerUnitIfIsInMousePosition();
        if (newSelectedUnit)
        {
            ChangeSelectedUnit(newSelectedUnit);
            return;
        }

        MoveUnitToMousePosition();
    }

    // Main Methods
    private void MoveUnitToMousePosition()
    {
        Vector3 mousePosition = MouseWorld.GetMouseWorldPosition();
        _playerUnitSelected.ChangeTargetPosition(mousePosition);
    }


    private PlayerUnit GetPlayerUnitIfIsInMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _unitLayerMask);

        if (raycastHit.collider == null)
        {
            return null;
        }

        return raycastHit.collider.GetComponent<PlayerUnit>();
    }

    private void ChangeSelectedUnit(PlayerUnit newSelectedUnit)
    {
        _playerUnitSelected.SetSelected(false);
        _playerUnitSelected = newSelectedUnit;
        _playerUnitSelected.SetSelected(true);
    }
}
