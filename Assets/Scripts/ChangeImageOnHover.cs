using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeImageOnHover : Selectable, IPointerClickHandler
{
    void Deselect()
    {
        this.DoStateTransition(SelectionState.Disabled,true);
        this.DoStateTransition(SelectionState.Normal, true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Deselect();
    }
}
