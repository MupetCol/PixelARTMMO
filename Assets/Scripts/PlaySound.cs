using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void PlayClip(string clipName)
    {
        AudioManager.instance.Play(clipName);
    }
}
