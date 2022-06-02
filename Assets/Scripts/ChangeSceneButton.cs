using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void ChangeScene(string sceneName)
    {
        LevelManager.instance.LoadScene(sceneName);
    }

}
