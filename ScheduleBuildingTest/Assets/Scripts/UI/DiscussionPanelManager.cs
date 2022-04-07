using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscussionPanelManager : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    public TMP_InputField chatBox;
    public DiscussionBoard db;
    public SentimentGrammar sg;
    public Player player;
    public string sentiment;

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

        sentiment = sg.GetSentiment(text);

        switch (sentiment)
        {
            case "positive":
                player.ChangeMotivation(-2);
                db.IncreaseKarma(5);
                break;
            case "negative":
                player.ChangeMotivation(5);
                db.DecreaseKarma(3);
                break;
            default:
                break;
        }

        db.FetchScore();

        if (db.karma > 10)
        {
            player.AddCard(20);
            player.AddCard(20);
        }
        else if(db.karma > 3)
        {
            player.AddCard(20);
        }
        else if(db.karma > -4)
        {
        }
        else if(db.karma > -15)
        {
            player.AddCard(0);
        }
        else
        {
            player.AddCard(0);
            player.AddCard(0);
        }

        
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
}
