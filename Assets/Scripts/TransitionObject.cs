using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionObject : MonoBehaviour
{
    public int index;
    private void OnEnable()
    {
        SceneLoader.instance.LoadSingleScene(index);
    }
}
