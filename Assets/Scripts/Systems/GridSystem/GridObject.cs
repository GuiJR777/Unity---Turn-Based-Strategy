using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private PlayerUnit playerUnit;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        string playerUnitName = playerUnit == null ? "null" : playerUnit.Name;
        return $"{gridPosition.ToString()},\n{playerUnitName}";
    }

    public void SetPlayerUnit(PlayerUnit playerUnit)
    {
        this.playerUnit = playerUnit;
    }

    public void ClearPlayerUnit()
    {
        playerUnit = null;
    }

    public bool HasPlayerUnit()
    {
        return playerUnit != null;
    }

    public PlayerUnit GetPlayerUnit()
    {
        return playerUnit;
    }
}
