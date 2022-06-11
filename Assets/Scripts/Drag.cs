using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private RectTransform chatBox;
    float initPos = 0;
    float resizer = 0;



    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        resizer = (initPos - position.y);
        initPos = position.y;
        Vector2 rectSize = initPos > position.y ? new Vector2(chatBox.sizeDelta.x, Mathf.Clamp(chatBox.sizeDelta.y - resizer, 105, 500))
            : new Vector2(chatBox.sizeDelta.x, Mathf.Clamp(chatBox.sizeDelta.y + resizer, 105, 500));
        chatBox.sizeDelta = rectSize;
    }
}

