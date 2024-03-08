using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask _layerMaskToHit;

    // Singleton
    private static MouseWorld _instance;

    // MonoBehaviour Methods
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Main Methods
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _instance._layerMaskToHit);
        return raycastHit.point;
    }
}
