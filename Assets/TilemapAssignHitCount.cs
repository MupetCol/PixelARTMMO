using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapAssignHitCount : MonoBehaviour
{
    [SerializeField] private Tilemap tilemaps;
    int height, width;
    string spriteName;
    private int[,] terrainMap;




    public void AssignHitResistance()
    {

        width = tilemaps.cellBounds.size.x;
        height = tilemaps.cellBounds.size.y;
        terrainMap = new int[width, height];
        int counterX = 0;
        int counterY = 0;
        for (int initPosX = tilemaps.cellBounds.x; initPosX < width/2+1; initPosX++)
        {
            counterY = 0;
            for (int initPosY = tilemaps.cellBounds.y; initPosY < height/2+1; initPosY++)
            {
                if(tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)) != null)
                {
                    spriteName = tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)).name;
                    //Debug.Log("Array is: [" + counterX + "] [" + counterY + "] " + "Sprite world pos: " + tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)));
                    if (spriteName.Contains("Dirt"))
                    {
                        terrainMap[counterX, counterY] = 1;
                    }
                    else
                    {
                        terrainMap[counterX, counterY] = 2;
                    }
                    counterY++;
                }

            }
            counterX++;
        }
        MouseRaycast.instance.eve_MouseClick.AddListener(DealHit);
    }

    void DealHit()
    {
        int xBoundMinPos = Mathf.Abs(tilemaps.cellBounds.x);
        int yBoundMinPos = Mathf.Abs(tilemaps.cellBounds.y);


        Vector3Int posOffset = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)tilemaps.layoutGrid.transform.position.x,
        MouseRaycast.instance.mousePos.y - (int)tilemaps.layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)tilemaps.layoutGrid.transform.position.z);

        if (tilemaps.GetTile(posOffset) != null)
        {
            int indexX = posOffset.y > 0? xBoundMinPos - Mathf.Abs(posOffset.y): Mathf.Abs(posOffset.y) + xBoundMinPos;
            int indexY = posOffset.x > 0? yBoundMinPos - Mathf.Abs(posOffset.x): Mathf.Abs(posOffset.x) + yBoundMinPos;

            terrainMap[indexX, indexY]--;
            Debug.Log(indexX + " " + indexY);
            if(terrainMap[indexX, indexY] <= 0)
            {
                tilemaps.SetTile(posOffset, null);
            }
        }
    }
}
