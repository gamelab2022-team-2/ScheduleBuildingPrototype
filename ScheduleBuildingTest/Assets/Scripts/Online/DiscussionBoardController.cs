using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class DiscussionBoardController : MonoBehaviour
{
    public DiscussionBoard db;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoginRoutine());
        InvokeRepeating("fetch", 2f, 1f);
    }

    void fetch()
    {
        db.FetchScore();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", "userid");
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
