using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimationsOnHover : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Hovered", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Hovered", false);
    }

    
}
