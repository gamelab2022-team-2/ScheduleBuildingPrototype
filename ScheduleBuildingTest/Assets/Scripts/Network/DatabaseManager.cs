using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using TMPro;
using System;

public class DatabaseManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField messageInput;

    private string userID;
    private DatabaseReference databaseReference;

    [SerializeField]
    private GameObject chatBox;

    // Start is called before the first frame update
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {
        if (usernameInput.text != "" && messageInput.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            CreateUser();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(GetMessage());
        }
    }

    public void CreateUserButtom()
    {
        if (usernameInput.text != "" && messageInput.text != "")
        {
            CreateUser();
        }
    }

    public void CreateUser()
    {
        userID = usernameInput.text;
        User newUser = new User(usernameInput.text, messageInput.text);
        string json = JsonUtility.ToJson(newUser);

        databaseReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetMessage()
    {
        var dbTask = databaseReference.Child("users").OrderByChild("message").GetValueAsync();
        yield return new WaitUntil(predicate: () => dbTask.IsCompleted);

        if (dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {dbTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = dbTask.Result;
            
            foreach (Transform child in chatBox.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (DataSnapshot childSnapshot in snapshot.Children)
            {
                string message = childSnapshot.Child("message").Value.ToString();
                Debug.Log(message);
                gameObject.GetComponent<DiscussionPanelManager>().SendMessageToChat(message);

            }
        }
    }
}
