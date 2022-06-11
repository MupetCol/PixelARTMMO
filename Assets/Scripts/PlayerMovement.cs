using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Character2DController controller;
    private Animator[] animators;
    [SerializeField] Image left, right, jumpS, punch;
    [SerializeField] Sprite leftPressed, rightPressed, jumpPressed, punchPressed;
    Sprite sLeft, sRight, sJump, sPunch;

    public float runSpeed = 40f;

    public float horizontalMove = 0;
    public bool jump = false;

    public bool usingButton = false;

    bool crouch = false;

    private void Start()
    {
        StartCoroutine(findPlayer());
        sLeft = left.sprite;
        sRight = right.sprite;
        sJump = jumpS.sprite;
        sPunch = punch.sprite;
    }
    // Get input in the update method
    private void Update()
    {
        //Change sprites of UI buttons when using key bindings
        if (Input.GetAxisRaw("Horizontal") < 0) left.sprite = leftPressed;
        if (Input.GetAxisRaw("Horizontal") > 0) right.sprite = rightPressed;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            right.sprite = sRight;
            left.sprite = sLeft;
        }
        if (Input.GetButtonDown("Jump")) StartCoroutine(Jumped());




        if (controller != null)
        {
            //Update animations here so it works for both buttons and keyboard
            setFloatAnimatorParam("Speed", Mathf.Abs(horizontalMove));
            //animators.SetFloat("Speed", Mathf.Abs(horizontalMove));





        }
        if (!usingButton && controller != null)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;





            if (Input.GetButtonDown("Jump")) jump = true;



            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }

    }

    void Landed()
    {
        if (controller.m_Grounded) jumpS.sprite = sJump;
    }

    IEnumerator Jumped()
    {
        jumpS.sprite = jumpPressed;
        yield return new WaitForSeconds(.5f);
        jumpS.sprite = sJump;

    }
    IEnumerator findPlayer()
    {
        yield return new WaitForSeconds(1f);
        controller = FindObjectOfType<Character2DController>();
        animators = controller.gameObject.GetComponentsInChildren<Animator>();
    }

    private void FixedUpdate()
    // Apply input to player physics on FixedUpdate
    {
        if(controller != null)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }

    }

    public void MoveLeftWithButton(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        usingButton = true;
        horizontalMove = -1 * runSpeed;
    }

    public void MoveRightWithButton(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        usingButton = true;
        horizontalMove = 1 * runSpeed;
    }

    public void JumpWithButton(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        usingButton = true;
        jump = true;
    }

    public void ButtonUp(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        usingButton = false;
    }

    void setFloatAnimatorParam(string param, float value)
    {
        foreach(Animator a in animators)
        {
            a.SetFloat(param,value);
        }
    }

}
