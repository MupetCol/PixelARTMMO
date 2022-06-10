using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseRaycast : MonoBehaviour
{
    //Mouse Position
    public Vector3Int mousePos { get { return MousePos; } private set { MousePos = value; } }
    [SerializeField]
    private Vector3Int MousePos;

    public UnityEvent eve_MouseClick;

    public static MouseRaycast instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (eve_MouseClick == null)
            eve_MouseClick = new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && eve_MouseClick != null)
        {
            eve_MouseClick.Invoke();
        }

        Vector3 mouseWolrdPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = Vector3Int.FloorToInt(new Vector3(mouseWolrdPosition.x, mouseWolrdPosition.y,0));

    }
}