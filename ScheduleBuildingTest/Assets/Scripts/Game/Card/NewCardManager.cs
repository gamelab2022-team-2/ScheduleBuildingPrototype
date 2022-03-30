using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;
using Game;
using TMPro;

public class NewCardManager : MonoBehaviour
{
    public Player player;
    public GameStateMachine stateMachine;
    private List<int> _threeCards;
    public TextMeshProUGUI[] title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNewCardOpts()
    {
        _threeCards = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(4, player.allCards.Count - 1);

            while (_threeCards.Contains(index) || index == 10) //can't be Yoga
            {
                index = Random.Range(4, player.allCards.Count - 1);
            }

            _threeCards.Add(index);
            Debug.Log(player.allCards.GetAtIndex(_threeCards[i]));

            //temporary text display TODO: use actual card art
            title[i].text = player.allCards.GetAtIndex(_threeCards[i]).cardName;
        }
    }

    public void ApplyChoice(int selection)
    {
        Debug.Log("new card state button pressed");

        if (_threeCards.Count != 0)
        {
            player.AddCard(_threeCards[selection - 1]);
            Debug.Log(player.allCards.GetAtIndex(_threeCards[selection - 1]));
        }
        else
        {
            Debug.Log("New Card State got no cards :(");
        }

        player.deck.Shuffle();
    }
}
