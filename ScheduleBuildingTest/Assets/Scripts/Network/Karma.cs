using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Karma : MonoBehaviour
{
    public int karma = 0;
    PhotonView pv;
    public TextMeshProUGUI karmaDisplay;


    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            increaseKarma();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            decreaseKarma();
    }
    
    public void increaseKarma()
    {
        pv.RPC("increaseKarmaRPC", RpcTarget.All);
    }

    public void decreaseKarma()
    {
        pv.RPC("decreasrKarmaRPC", RpcTarget.All);
    }

    [PunRPC]
    void increaseKarmaRPC()
    {
        karma++;
        karmaDisplay.text = "Karma: " + karma.ToString();
    }

    [PunRPC]
    void decreasrKarmaRPC()
    {
        karma--;
        karmaDisplay.text = "Karma: " + karma.ToString();
    }
}
