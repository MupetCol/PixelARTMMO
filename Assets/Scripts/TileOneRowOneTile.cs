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
