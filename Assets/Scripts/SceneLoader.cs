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
        DontDestroyOnLoad(loadingScreen);
    }
 
    public void LoadScene(int index)
    {
        loadingScreen.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress(index));
    }

    IEnumerator GetSceneLoadProgress(int index)
    {
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalSceneProgress = 0;
 
                foreach (AsyncOperation operation in scenesToLoad)
                {
                    totalSceneProgress += operation.progress;
                }
 
                totalSceneProgress = (totalSceneProgress / scenesToLoad.Count) * 1f;
                loadingBar.value = Mathf.RoundToInt(totalSceneProgress);
 
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        loadingScreen.SetActive(false);
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