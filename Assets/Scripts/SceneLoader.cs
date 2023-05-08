using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public GameObject loadingScreen;
    public Slider loadingBar;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadScenes();
        }
        else
        {
            Destroy(this);
        }
    }
     
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }
 
    void LoadScenes()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)forestScenes.InteractiveHub, LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)forestScenes.BurntForest, LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)forestScenes.BurningForest, LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)forestScenes.Forest, LoadSceneMode.Additive));
    }

    void LoadScene(int index)
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive));
    }
}

enum forestScenes {
    //Hub 0
    //Burnt Forest 1
    //Burning Forest 2
    //Forest 3
    InteractiveHub = 0,
    BurntForest = 1,
    BurningForest = 2,
    Forest = 3,
    TitleScreen = 4
} 