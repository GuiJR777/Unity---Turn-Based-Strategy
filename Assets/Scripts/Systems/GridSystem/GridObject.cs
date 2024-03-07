using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<PlayerUnit> playerUnits;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        playerUnits = new List<PlayerUnit>();
    }

    public override string ToString()
    {
        string playerUnitNames = "";
        foreach (PlayerUnit playerUnit in playerUnits)
        {
            playerUnitNames += playerUnit.Name + "\n";
        }
        return $"{gridPosition}\n{playerUnitNames}";
    }

    public void AddPlayerUnit(PlayerUnit playerUnit)
    {
        playerUnits.Add(playerUnit);
    }

    public void RemovePlayerUnit(PlayerUnit playerUnit)
    {
        playerUnits.Remove(playerUnit);
    }

    public bool HasPlayerUnit()
    {
        return playerUnits.Count > 0;
    }

    public List<PlayerUnit> GetPlayerUnits()
    {
        return playerUnits;
    }
}
