using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapUnifier : MonoBehaviour
{
    public Tilemap mainTileMap;
    public Tilemap[] mapsToUnify;
    public Tile[] respectiveTileUnify;

    public Tilemap[] mapsToIsolate;
    BoundsInt bounds;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Unify();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Isolate();
        }
    }

    void Unify()
    {
        for (int i = 0; i < mapsToUnify.Length; i++)
        {
            bounds = mapsToUnify[i].cellBounds;
            foreach(var cell in bounds.allPositionsWithin)
            {
                Vector3Int offsetConversion = Vector3Int.FloorToInt(mapsToUnify[i].layoutGrid.transform.position);
                if (mapsToUnify[i].GetTile(cell) != null)
                {  
                    mainTileMap.SetTile(cell+offsetConversion, respectiveTileUnify[i]);
                }
            }
            Destroy(mapsToUnify[i].gameObject);
        }
    }

    void Isolate()
    {
        for (int i = 0; i < mapsToIsolate.Length; i++)
        {
            bounds = mapsToIsolate[i].cellBounds;
            foreach (var cell in bounds.allPositionsWithin)
            {
                Vector3Int offsetConversion = Vector3Int.FloorToInt(mapsToIsolate[i].layoutGrid.transform.position);
                if (mapsToIsolate[i].GetTile(cell) != null)
                {
                    mainTileMap.SetTile(cell + offsetConversion, null);
                }
            }
        }
    }
}
