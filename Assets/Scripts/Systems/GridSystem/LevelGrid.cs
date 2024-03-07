using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform debugLabelPrefab;
    private GridSystem gridSystem;

    public static LevelGrid Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugLabels(debugLabelPrefab);
    }

    public void AddUnitAtGridPosition(PlayerUnit unit, GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        if (gridObject == null)
        {
            return;
        }

        gridObject.AddPlayerUnit(unit);
    }

    public List<PlayerUnit> GetUnitsAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);

        if (gridObject == null)
        {
            return null;
        }

        if (!gridObject.HasPlayerUnit())
        {
            return null;
        }
        return gridObject.GetPlayerUnits();
    }

    public void RemoveUnitAtGridPosition(PlayerUnit unit, GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);

        if (gridObject == null)
        {
            return;
        }

        if (!gridObject.HasPlayerUnit())
        {
            return;
        }

        gridObject.RemovePlayerUnit(unit);
    }

    public void UnitMovedAtGridPosition(PlayerUnit unit, GridPosition oldGridPosition, GridPosition newGridPosition)
    {
        RemoveUnitAtGridPosition(unit, oldGridPosition);
        AddUnitAtGridPosition(unit, newGridPosition);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    // The same of the above method
    // public GridPosition GetGridPosition(Vector3 worldPosition)
    // {
    //     return gridSystem.GetGridPosition(worldPosition);
    // }
}
