using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public RectTransform titleImage;
    private float sceneEnterTime = 0;

    public void Start()
    {
        sceneEnterTime = Time.time;
        titleImage.DOLocalJump(new Vector2(0, 0), 100, 3, 1f).SetDelay(0.5f)
            .OnComplete(ScalePunch);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && Time.time - sceneEnterTime > 2f )
        {
            SceneManager.LoadScene(1);
        }
    }

    void ScalePunch()
    {
        titleImage.DOPunchScale(new Vector3(1.5f,1.5f,1.5f),0.5f,8,1f );
    }
}
