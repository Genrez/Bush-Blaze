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
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    float totalSceneProgress;

    private void Awake() 
    {
        instance = this;
    }
     
    void Start()
    {
        DontDestroyOnLoad(this);
        if (loadingScreen) 
        {
            DontDestroyOnLoad(loadingScreen);  
        }
    }
 
    public void LoadSpecificScene(int index) 
    {
        StartCoroutine(LoadSceneAsync(index));
    }

    IEnumerator LoadSceneAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }

    public void LoadSingleScene(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void LoadBurntForest()
    {
        SceneManager.LoadScene((int)forestScenes.BurntForest, LoadSceneMode.Single);
    }

    public void LoadBurningForest()
    {
        SceneManager.LoadScene((int)forestScenes.BurningForest, LoadSceneMode.Single);
    }

    public void LoadForest()
    {
        SceneManager.LoadScene((int)forestScenes.Forest, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
     
enum forestScenes 
{
    InteractiveHub = 0,
    BurntForest = 1,
    BurningForest = 2,
    Forest = 3,
    TitleScreen = 4
} 