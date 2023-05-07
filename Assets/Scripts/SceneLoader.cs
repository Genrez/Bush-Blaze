using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }
 
    void LoadScenes()
    {
          
    }
}
