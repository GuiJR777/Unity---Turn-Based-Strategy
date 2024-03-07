using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjects;

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjects = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
               GridPosition gridPosition = new GridPosition(x, z);
               gridObjects[x, z] = new GridObject(this, gridPosition);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
        );
    }

    public void CreateDebugLabels(Transform debugLabelPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Vector3 worldPosition = GetWorldPosition(gridPosition);
                Transform debugLabel = GameObject.Instantiate(debugLabelPrefab, worldPosition, Quaternion.identity);
                GridDebugLabel gridDebugLabel = debugLabel.GetComponent<GridDebugLabel>();
                gridDebugLabel.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        if (gridPosition.x < 0 || gridPosition.x >= width || gridPosition.z < 0 || gridPosition.z >= height)
        {
            return null;
        }
        return gridObjects[gridPosition.x, gridPosition.z];
    }

}
