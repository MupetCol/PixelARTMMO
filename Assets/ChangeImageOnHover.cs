using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeImageOnHover : Selectable, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
