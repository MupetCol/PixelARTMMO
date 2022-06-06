using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileOneRowOneTile : MonoBehaviour
{
    public Tilemap map;
    public Vector3Int mapSize;

    public Tile tile;
    public AnimatedTile animTile;

    int width = 1;
    int height = 0;
    public Vector3Int savedPos;



    private void Start()
    {
        MouseRaycast.instance.eve_MouseClick.AddListener(TryDelete);
    }

    private void TryDelete()
    {
        Vector3Int localPos = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)map.layoutGrid.transform.position.x,
        MouseRaycast.instance.mousePos.y - (int)map.layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)map.layoutGrid.transform.position.z);
        if (localPos.x < width && localPos.y < height)
        {
            map.SetTile(localPos, null);
        }

    }

    public void TileGen()
    {
        width = mapSize.x;
        height = mapSize.y;
        savedPos = new Vector3Int(Random.Range(-width / 2, width / 2), height, 0);
        map.SetTile(savedPos, tile);
    }

    public void AnimTileGen()
    {
        width = mapSize.x;
        height = mapSize.y;
        savedPos = new Vector3Int(Random.Range(-width / 2, width / 2), height, 0);
        map.SetTile(savedPos, animTile);
    }
}