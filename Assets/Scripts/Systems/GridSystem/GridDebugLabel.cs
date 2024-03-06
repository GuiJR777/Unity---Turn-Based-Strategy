using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugLabel : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    private GridObject gridObject;

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;

    }

    private void Update()
    {
        textMeshPro.text = gridObject.GetGridPosition().ToString();
    }
}
