using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MouseRaycast
{
    [Range(0, 100)]
    public int iniChance;

    [Range(1, 8)]
    public int birthLimit;

    [Range(1,8)]
    public int deathLimit;

    [Range(1, 10)]
    public int numR;

    public bool randomizeBottom;
    public bool randomizeTop;

    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmapSize;

    public Tilemap topMap;
    public Tilemap bottomMap;
    public List<Tile> topTile;
    public List<Tile> botTile;


    int width;
    int height;

    
    private void Start()
    {
        eve_MouseClick.AddListener(TryDelete);
    }

    private void TryDelete()
    {
        Vector3Int localPos = new Vector3Int(mousePos.x - (int)topMap.layoutGrid.transform.position.x,
        mousePos.y - (int)topMap.layoutGrid.transform.position.y, mousePos.z - (int)topMap.layoutGrid.transform.position.z);
        if (topMap.layoutGrid.tag == "BackLayer")
        {
            int indexy = localPos.y < 0 ? localPos.y*-1 + height/2 : localPos.y;
            int indexx = localPos.x < 0 ? localPos.x*-1 + width / 2 : localPos.x;
            if (terrainMap[indexx, indexy] == -1) terrainMap[indexx, indexy] = 0;
            else
            {
                topMap.SetTile(localPos, null);
                bottomMap.SetTile(localPos, null);
            }
        }
        else
        {
            topMap.SetTile(localPos, null);
            bottomMap.SetTile(localPos, null);
        }

    }

    public void doSim(int numR)
    {
        clearMap(false);
        width = tmapSize.x;
        height = tmapSize.y;


        if (terrainMap == null)
        {
            terrainMap = new int[width,height];
            initPos();
        }

        for (int i = 0; i < numR; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        
        

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1 && randomizeTop == false) 
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile[0]);
                else if(terrainMap[x, y] == 1 && randomizeTop == true)
                {
                    int indexT = Random.Range(0, topTile.Count);
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile[indexT]);
                }

                if(randomizeBottom == false)
                    bottomMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile[0]);
                else
                {
                    int indexB = Random.Range(0, botTile.Count);
                    bottomMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile[indexB]);
                }

            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = -1;
            }
        }

    }

    public int [,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width,height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach(var b in myB.allPositionsWithin)
                {
                    //Set boundaries for values
                    if (b.x == 0 && b.y == 0) continue;
                    if(x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        //We are not in the border of our tilemap yet
                        neighb += oldMap[x + b.x , y + b.y];
                    }
                    else
                    {
                        //Reached the border of our map
                        neighb++;
                    }
                }
                if (oldMap[x, y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }

                if (oldMap[x, y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }
        }


        return newMap;
    }

    public void initPos()
    {
        for (int x = 0; x  < width; x ++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            doSim(numR);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            clearMap(true);
        }

    }

    public void clearMap(bool complete)
    {
        topMap.ClearAllTiles();
        bottomMap.ClearAllTiles();

        if (complete)
        {
            terrainMap = null;
        }
    }
}
