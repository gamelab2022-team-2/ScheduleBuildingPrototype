using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckVisibility : MonoBehaviour
{
    public GameObject deck;
    public Player player;


    public void CheckIfEmpty()
    {
        if(player.deck.IsEmpty())
        {
            deck.gameObject.SetActive(false);
        }
        else
        {
            deck.gameObject.SetActive(true);
        }
    }
}
