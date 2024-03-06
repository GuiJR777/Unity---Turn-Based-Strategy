using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    [SerializeField] private Transform debugLabelPrefab;
    private GridSystem gridSystem;

    public void Start()
    {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugLabels(debugLabelPrefab);

        Debug.Log(new GridPosition(1, 2));
    }

}
