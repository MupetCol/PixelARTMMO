using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Character2DController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0;
    bool jump = false;

    bool crouch = false;

    // Get input in the update method
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       
        if (Input.GetButtonDown("Jump")) jump = true;
        


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) 
        {
            crouch = false;
        }

    }

    private void FixedUpdate()  
    // Apply input to player physics on FixedUpdate
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

}
