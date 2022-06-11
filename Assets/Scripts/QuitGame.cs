using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    public void Quit()
    {
        Application.Quit();
    }

    public void EnableQuitPopUp()
    {
        popUp.SetActive(true);
    }

    public void DisableQuitPopUp()
    {
        popUp.SetActive(false);
    }


}
