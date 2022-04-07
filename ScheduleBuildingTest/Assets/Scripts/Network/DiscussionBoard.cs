using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class DiscussionBoard : MonoBehaviour
{
    int boardID = 2133;
    public int karma = 0;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void IncreaseKarma(int increase)
    {
        karma += increase;
        SubmitScore(karma);
        
    }
    
    public void DecreaseKarma(int decrease)
    {
        karma-=decrease;
        SubmitScore(karma);
    }

    private void SubmitScore(int scoreToUpload)
    {
        string playerID = PlayerPrefs.GetString("PlayerID");
        
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, boardID, (response) =>
        {
            if (response.success)
                Debug.Log("Successfully uploaded score");
            else
                Debug.Log("Failed" + response.Error);
        });
    }

    public void FetchScore()
    {
        LootLockerSDKManager.GetScoreListMain(boardID, 1, 0, (response) =>
        {
            if (response.success)
            {
                string playerKarma = "Karma: ";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    playerKarma += members[i].score + "\n";
                    karma = members[i].score;
                }
                
            }
            else
            {
                Debug.Log("Failed" + response.Error);
            }
        });
    }
}
