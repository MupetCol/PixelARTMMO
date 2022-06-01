using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{
    public void Toggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
