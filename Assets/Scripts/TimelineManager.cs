using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;


public class TimelineManager : MonoBehaviour
{
    public static TimelineManager instance;
    public static bool Timeline0;
    public static bool Timeline1;
    public static bool Timeline2;
    public static bool Timeline3;
    public static bool Timeline4;
    public static bool Timeline5;
    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    void Start()
    {
        Timeline0 = true;
        Timeline1 = false;
        Timeline2 = false;
        Timeline3 = false;
        Timeline4 = false;
        Timeline5 = false;
    }

    void Update()
    {

    }

    public void Part0Done()
    {
        Timeline0 = false;
        Timeline1 = true;
    }

    public void Part1()
    {
        Timeline1 = false;
        Timeline2 = true;
    }

    public void Part2()
    {
        Timeline2 = false;
        Timeline3 = true;
    }

    public void Part3()
    {
        Timeline3 = false;
        Timeline4 = true;
    }

    public void Part4()
    {
        Timeline4 = false;
        Timeline5 = true;
    }
}
