using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager am;
    private float sceneEnterTime = 0;

    public void Start()
    {
        sceneEnterTime = Time.time;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && Time.time - sceneEnterTime > 2f )
        {
            am.StopMusic(0);
            SceneManager.LoadScene(1);
        }
    }

    void ScalePunch()
    {
    }
}
