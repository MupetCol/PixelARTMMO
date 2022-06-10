using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapAssignHitCount : MonoBehaviour
{
    [SerializeField] private Tilemap tilemaps;
    [SerializeField] private Tilemap tilemapFrontLayer;
    int height, width;
    string spriteName;
    private int[,] terrainMap;
    int xBoundMinPosTEST;
    int yBoundMinPosTEST;
    bool nowUpdate;

    private void Start()
    {
        //StartCoroutine(doShit());
    }
    IEnumerator doShit()
    {
        yield return new WaitForSeconds(1);
        xBoundMinPosTEST = Mathf.Abs(tilemaps.cellBounds.x);
        yBoundMinPosTEST = Mathf.Abs(tilemaps.cellBounds.y);
        nowUpdate = true;
    }

    private void Update()
    {
        if (nowUpdate)
        {
            Vector3Int posOffset = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)tilemaps.layoutGrid.transform.position.x,
            MouseRaycast.instance.mousePos.y - (int)tilemaps.layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)tilemaps.layoutGrid.transform.position.z);
            Debug.Log("USED FOR X: " + posOffset.y + " USED FOR Y: " + posOffset.x);

            int indexX = posOffset.y > 0 ? Mathf.Abs(yBoundMinPosTEST) - Mathf.Abs(posOffset.y) : Mathf.Abs(posOffset.y) + Mathf.Abs(yBoundMinPosTEST);
            int indexY = posOffset.x < 0 ? Mathf.Abs(xBoundMinPosTEST) - Mathf.Abs(posOffset.x) : Mathf.Abs(posOffset.x) + Mathf.Abs(xBoundMinPosTEST);
            Debug.Log("INDEX GENERATED FOR ARRAY X: " + indexX + " INDEX GENERATED FOR ARRAY Y: " + indexY);
        }

    }

    public void AssignHitResistance()
    {

        width = tilemaps.cellBounds.size.x;
        height = tilemaps.cellBounds.size.y;
        terrainMap = new int[width, height];
        int counterX = 0;
        int counterY = 0;
        for (int initPosX = tilemaps.cellBounds.x; initPosX < width/2 + width%2; initPosX++)
        {
            counterY = height - 1;

            for (int initPosY = tilemaps.cellBounds.y; initPosY < height/2 + height%2; initPosY++)
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
                    counterY--;
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
            //Debug.Log("REAL POSITION OF TILE: "+posOffset);
            int indexX = posOffset.y > 0 ? Mathf.Abs(yBoundMinPos) - Mathf.Abs(posOffset.y) : Mathf.Abs(posOffset.y) + Mathf.Abs(yBoundMinPos);
            int indexY = posOffset.x < 0 ? Mathf.Abs(xBoundMinPos) - Mathf.Abs(posOffset.x) : Mathf.Abs(posOffset.x) + Mathf.Abs(xBoundMinPos);

            if(tilemaps.transform.tag == "BackLayer" && tilemapFrontLayer != null)
            {
                Vector3Int posOffsetOther = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)tilemapFrontLayer.layoutGrid.transform.position.x,
                MouseRaycast.instance.mousePos.y - (int)tilemapFrontLayer.layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)tilemapFrontLayer.layoutGrid.transform.position.z);
                if (tilemapFrontLayer.GetTile(posOffsetOther) == null)
                {
                    Debug.Log(tilemapFrontLayer.GetTile(posOffsetOther));
                    Debug.Log("Trying to reach 1");
                    terrainMap[indexY, indexX]--;
                }
            }
            else
            {
                terrainMap[indexY, indexX]--;
            }


            if(terrainMap[indexY, indexX] <= 0)
            {
                tilemaps.SetTile(posOffset, null);
            }
        }
    }
}
