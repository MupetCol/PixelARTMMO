using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapUnifier : MonoBehaviour
{
    public Tilemap mainTileMap;
    public Tilemap[] mapsToUnify;

    public Tilemap[] mapsToIsolate;
    BoundsInt bounds;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Unify();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Isolate();
        }
    }

    public void Unify()
    {
        for (int i = 0; i < mapsToUnify.Length; i++)
        {
            bounds = mapsToUnify[i].cellBounds;
            foreach(var cell in bounds.allPositionsWithin)
            {
                Vector3 offsetsSubt = new Vector3(mapsToUnify[i].layoutGrid.transform.position.x - mainTileMap.layoutGrid.transform.position.x,
                    mapsToUnify[i].layoutGrid.transform.position.y - mainTileMap.layoutGrid.transform.position.y,
                    mapsToUnify[i].layoutGrid.transform.position.z - mainTileMap.layoutGrid.transform.position.z);
                Vector3Int offsetConversionOtherMap = Vector3Int.FloorToInt(offsetsSubt);
                if (mapsToUnify[i].GetTile(cell) != null)
                {
                    mainTileMap.SetTile(cell+ offsetConversionOtherMap, mapsToUnify[i].GetTile(cell));
                }
            }
            Destroy(mapsToUnify[i].gameObject);
        }
    }

    public void Isolate()
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
