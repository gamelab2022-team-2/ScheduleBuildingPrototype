using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public RectTransform title, introPanel;

    public void OpenTitle()
    {
        title.gameObject.SetActive(true);
    }

    public void CloseTitle()
    {
        title.gameObject.SetActive(false);
    }

    public void OpenIntroPanel()
    {
        introPanel.gameObject.SetActive(true);
    }

    public void CloseIntroPanel()
    {
        introPanel.gameObject.SetActive(false);
    }
}
