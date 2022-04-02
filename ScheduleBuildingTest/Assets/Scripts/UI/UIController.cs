using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public RectTransform eventPanel,newCardPanel, gameOverPanel;
    public Transform schedule;
        
    public void OpenEventPanel()
    {
        eventPanel.gameObject.SetActive(true);
        eventPanel.DOAnchorPos(new Vector2(0, -50), 0.25f).SetDelay(0.25f);
    }
    public void CloseEventPanel()
    {
        eventPanel.DOAnchorPos(new Vector2(-1700, -50), 0.25f).SetDelay(0.1f);
        eventPanel.gameObject.SetActive(true);
    }
    
    public void OpenNewCardPanel()
    {
        newCardPanel.gameObject.SetActive(true);
        newCardPanel.DOAnchorPos(new Vector2(0, 0), 0.25f).SetDelay(0.25f);
    }
    public void CloseNewCardPanel()
    {
        newCardPanel.DOAnchorPos(new Vector2(0, -1000), 0.25f).SetDelay(0.1f);
        newCardPanel.gameObject.SetActive(true);
    }
    
    public void OpenSchedule()
    {
        
        schedule.DOMove(new Vector3(0, 0,0), 0.25f);
    }
    public void CloseSchedule()
    {
        schedule.DOMove(new Vector3(0, 13,0), 0.25f).SetDelay(0.1f);
    }

    public void OpenGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.DOAnchorPos(new Vector2(0, 0), 0.25f).SetDelay(0.25f);
    }

    public void CloseGameOver()
    {
        gameOverPanel.DOAnchorPos(new Vector2(0, -1000), 0.25f).SetDelay(0.1f);
        gameOverPanel.gameObject.SetActive(true);
    }
}
