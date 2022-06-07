using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private GameObject _canvasToDeactivate;
    [SerializeField] private Image _progressBar;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        AudioManager.instance.StopPlaying(AudioManager.instance.sounds[0].name);
        AudioManager.instance.Play("LoadingMusic");
        _loaderCanvas.SetActive(true);

        do
        {
            //Delete later
            await System.Threading.Tasks.Task.Delay(100);
            _progressBar.fillAmount = scene.progress;

        } while (scene.progress < 0.9f);

        //Delete later
        await System.Threading.Tasks.Task.Delay(1000);

        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
        AudioManager.instance.StopPlaying("LoadingMusic");
        AudioManager.instance.Play(AudioManager.instance.sounds[0].name);
    }
}
