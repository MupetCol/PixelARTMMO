using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapAssignHitCount : MonoBehaviour
{
    [SerializeField] private Tilemap tilemaps;
    [SerializeField] private Tilemap[] tilemapFrontLayer;
    int height, width;
    string spriteName;
    private int[,] terrainMap;
    int xBoundMinPosTEST;
    int yBoundMinPosTEST;
    bool nowUpdate;

    private void Start()
    {
        StartCoroutine(doShit());
    }
    IEnumerator doShit()
    {
        yield return new WaitForSeconds(1);
        xBoundMinPosTEST = Mathf.Abs(tilemaps.cellBounds.x);
        yBoundMinPosTEST = Mathf.Abs(tilemaps.cellBounds.y)+1;
        nowUpdate = true;
    }

    private void Update()
    {
        if (nowUpdate)
        {
            Vector3Int posOffset = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)tilemaps.layoutGrid.transform.position.x,
            MouseRaycast.instance.mousePos.y - (int)tilemaps.layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)tilemaps.layoutGrid.transform.position.z);
            Debug.Log("USED FOR X: " + posOffset.x + " USED FOR Y: " + posOffset.y);

            int indexX = posOffset.y > 0 ? Mathf.Abs(yBoundMinPosTEST) - Mathf.Abs(posOffset.y) : Mathf.Abs(posOffset.y) + Mathf.Abs(yBoundMinPosTEST);
            int indexY = posOffset.x < 0 ? Mathf.Abs(xBoundMinPosTEST) - Mathf.Abs(posOffset.x) : Mathf.Abs(posOffset.x) + Mathf.Abs(xBoundMinPosTEST);
            Debug.Log("INDEX GENERATED FOR ARRAY X: " + indexY + " INDEX GENERATED FOR ARRAY Y: " + indexX);
        }

    }

    public void AssignHitResistance()
    {

        width = tilemaps.cellBounds.size.x;
        height = tilemaps.cellBounds.size.y;
        terrainMap = new int[width, height];
        int counterX = 0;
        int counterY = 0;
        for (int initPosX = tilemaps.cellBounds.x; initPosX < width/2 + 1; initPosX++)
        {
            //Debug.Log("BOUND X: " + initPosX);
            counterY = height-1;


            for (int initPosY = tilemaps.cellBounds.y; initPosY < height/2 + 1; initPosY++)
            {
                //Debug.Log("BOUND Y: " + initPosY);
                if(tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)) != null)
                {
                    spriteName = tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)).name;
                    //Debug.Log("Array is: [" + counterX + "] [" + counterY + "] " + "Sprite world pos: " + tilemaps.GetSprite(new Vector3Int(initPosX, initPosY, 0)));
                    if (spriteName.Contains("Dirt"))
                    {
                        //Debug.Log("FOUND DIRT AT: " + counterY + " " + counterX);
                        terrainMap[counterX, counterY] = 1;
                    }
                    else
                    {
                        terrainMap[counterX, counterY] = 2;
                    }
                    //Debug.Log("COUNTER " + counterY);
                }
                counterY--;

            }
            counterX++;
        }

        //for (int i = 0; i < width; i++)
        //{
        //    Debug.Log("\n");
        //    for (int k = 0; k < height; k++)
        //    {
        //        Debug.Log(terrainMap[i, k] + " ");
        //    }

        //}
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
            int indexX = posOffset.y > 0 ? Mathf.Abs(yBoundMinPos) - Mathf.Abs(posOffset.y) : Mathf.Abs(posOffset.y) + Mathf.Abs(yBoundMinPos);
            int indexY = posOffset.x < 0 ? Mathf.Abs(xBoundMinPos) - Mathf.Abs(posOffset.x) : Mathf.Abs(posOffset.x) + Mathf.Abs(xBoundMinPos);



            if (tilemaps.transform.tag == "BackLayer" && tilemapFrontLayer[0] != null)
            {
                int counter = 0;
                for(int i = 0; i < tilemapFrontLayer.Length; i++)
                {
                    Vector3Int posOffsetOther = new Vector3Int(MouseRaycast.instance.mousePos.x - (int)tilemapFrontLayer[i].layoutGrid.transform.position.x,
                    MouseRaycast.instance.mousePos.y - (int)tilemapFrontLayer[i].layoutGrid.transform.position.y, MouseRaycast.instance.mousePos.z - (int)tilemapFrontLayer[i].layoutGrid.transform.position.z);
                    if (tilemapFrontLayer[i].GetTile(posOffsetOther) == null)
                    {
                        counter++;
                    }

                    if(counter == tilemapFrontLayer.Length)
                    {
                        terrainMap[indexY, indexX]--;
                    } 
                }
                counter = 0;

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
