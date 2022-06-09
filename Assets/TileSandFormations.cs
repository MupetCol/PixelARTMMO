using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSandFormations : MonoBehaviour
{
    public Tilemap tileMap;
    public Tile tile;
    public Vector3Int tmapSize;
    public int sandClumpsQuantity = 0;
    BoundsInt myB;
    void Start()
    {
        myB = new BoundsInt(-2, -2, 0, 5, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GenerateSand();
        }
    }

    void GenerateSand()
    {
     
        for (int i = 0; i < sandClumpsQuantity; i++)
        {
            int initPos = Random.Range(-(tmapSize.x/2), tmapSize.x/2);
            foreach(var cell in myB.allPositionsWithin)
            {
                if (cell.x == -2 && cell.y == -1) continue;
                if (cell.x == 2 && cell.y == -1) continue;
                if (cell.x == -2 && cell.y == -2) continue;
                if (cell.x == -1 && cell.y == -2) continue;
                if (cell.x == 1 && cell.y == -2) continue;
                if (cell.x == 2 && cell.y == -2) continue;
                Vector3Int posTile = new Vector3Int(cell.x + initPos, cell.y, cell.z);
                tileMap.SetTile(posTile, tile);
            }
        }
    }
}
