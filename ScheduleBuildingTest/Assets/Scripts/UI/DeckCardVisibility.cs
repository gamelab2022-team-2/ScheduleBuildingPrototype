using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardVisibility : MonoBehaviour
{
    public Player player;
    public GameObject deckTopCard;

    public void CheckIfEmpty()
    {
        if (player.deck.CheckIfEmpty())
        {
            deckTopCard.gameObject.SetActive(false);
        }
        else
        {
            deckTopCard.gameObject.SetActive(true);
        }
    }
      
      


}
