using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseRaycast : MonoBehaviour
{
    //Mouse Position
    [SerializeField] private Camera mainCamera;
    public Vector3Int mousePos;

    public UnityEvent eve_MouseClick;

    public static MouseRaycast instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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

        Vector3 mouseWolrdPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWolrdPosition.z = 0f;
        mousePos = Vector3Int.FloorToInt(mouseWolrdPosition);

    }
}