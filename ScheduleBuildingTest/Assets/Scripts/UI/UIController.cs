using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public RectTransform eventPanel,newCardPanel, gameOverPanel, introPanel, winPanel, tempInfoPanel;
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
        gameOverPanel.gameObject.SetActive(false);
    }

    public void OpenWinPanel()
    {
        winPanel.gameObject.SetActive(true);
        winPanel.DOAnchorPos(new Vector2(0, 0), 0.25f).SetDelay(0.25f);
    }

    public void CloseWinPanel()
    {
        winPanel.DOAnchorPos(new Vector2(0, -1000), 0.25f).SetDelay(0.1f);
        winPanel.gameObject.SetActive(false);
    }

    public void OpenIntro()
    {
        introPanel.gameObject.SetActive(true);
        introPanel.DOAnchorPos(new Vector2(0, 0), 0.25f).SetDelay(0.25f);
    }

    public void CloseIntro()
    {
        introPanel.DOAnchorPos(new Vector2(0, -1000), 0.25f).SetDelay(0.1f);
        introPanel.gameObject.SetActive(false);
    }

    public void OpenTempInfo()
    {
        tempInfoPanel.gameObject.SetActive(true);
    }

    public void CloseTempInfo()
    {
        tempInfoPanel.gameObject.SetActive(false);
    }
}
