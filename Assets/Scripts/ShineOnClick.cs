using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class ShineOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler   
{
    private TMP_Text text;
    private Image icon;
    private Color tempColor;
    private float tempSize;
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        tempColor = text.color;
        tempSize = text.fontSize;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.color = Color.white;
        text.fontSize = tempSize + 4f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.color = tempColor;
        text.fontSize = tempSize;
    }
}
