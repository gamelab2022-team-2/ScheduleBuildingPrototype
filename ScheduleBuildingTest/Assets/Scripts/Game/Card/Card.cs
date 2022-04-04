using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    // played variables

    public string shape;
    public Color shapeColor;
    public int cardId;
    public CardType type;
    public string cardName;



    public List<string> placedResolve;
    public List<int> placedResolveParams;

    public List<string> unplacedResolve;
    public List<int> unplacedResolveParams;

    public List<string> onDraw;
    public List<int> onDrawParams;

    public bool burnAfterUse;

    void Start()
    {
        
        if (cardData != null)
        {
            LoadData(cardData);
        }
    }
    
    public void LoadData(CardData data)
    {
        //Debug.Log("Loading card data: " + data.cardName);
        
        cardId = data.cardId;
        type = data.type;
        cardName = data.cardName;

        shapeColor = data.shapeColor;
        shape = data.shape;

        placedResolve = data.placedResolve;
        placedResolveParams = data.placedResolveParams;

        unplacedResolve = data.unplacedResolve;
        unplacedResolveParams = data.unplacedResolveParams;

        onDraw = data.onDraw;
        onDrawParams = data.onDrawParams;

        burnAfterUse = data.burnAfterUse;
    }
    

}
