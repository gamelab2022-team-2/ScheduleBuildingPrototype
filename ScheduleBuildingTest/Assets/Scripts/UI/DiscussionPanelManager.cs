using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscussionPanelManager : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    public TMP_InputField chatBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                //chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

    }

    public void SendButton()
    {
        SendMessageToChat(chatBox.text);
    }

    public void SendMessageToChat(string text)
    {            
        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<TMP_Text>();
        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
}
