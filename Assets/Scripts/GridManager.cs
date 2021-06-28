using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : SingletonClass<GridManager>
{
    [SerializeField]
    GridTile gridTilePrefab;

    [SerializeField]
    Transform playArea;
    [SerializeField]
    int gridSize = 10;

    public int GridSize
    {
        get { return gridSize; }
    }

    Vector3 startPoint;
    public Vector3 StartPoint 
    {
        get { return startPoint; }
    }

    int width, height;

    Transform[,] grid;

    public void InstializeGrid()
    {
        width = Mathf.RoundToInt(playArea.localScale.x * gridSize);
        height = Mathf.RoundToInt(playArea.localScale.y * gridSize);
        grid = new Transform[width, height];
        startPoint = playArea.GetComponent<Renderer>().bounds.min;
        //Debug.Log(startPoint);
        //Debug.Log(playArea.GetComponentInChildren<Renderer>().bounds.max);
        CreateGridTile();

    }

    private void CreateGridTile()
    {
        if(gridTilePrefab == null)
        {
            return;
        }
        for(int i = 0; i < width; i++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 worldPos = GetWorldPos(i,y);
                GridTile gridTile = Instantiate(gridTilePrefab, worldPos, Quaternion.identity);
                gridTile.name = string.Format("Tile({0},{1})", i, y);
                grid[i, y] = gridTile.transform;
            }
        }
    }

    private Vector3 GetWorldPos(int a,int b)
    {
        float sp = a;
        float ep = b;
        return new Vector3(startPoint.x + (sp / gridSize), startPoint.y + (ep / gridSize),startPoint.z-0.1f);
    }

    // Start is called before the first frame update
    public void Start()
    {
        InstializeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
