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

    public void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, Vector3.one * 0.2f);
    }



    public void LoadData(CardData data)
    {
        Debug.Log("Loading card data: " + data.cardName);
        
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

    /*public Card(Card data)
    {


        this.cardData = data.cardData;

        this.cardId = data.cardId;
        this.type = data.type;
        this.cardName = data.cardName;

        this.shapeColor = data.shapeColor;
        this.shape = data.shape;

        this.placedResolve = data.placedResolve;
        this.placedResolveParams = data.placedResolveParams;

        this.unplacedResolve = data.unplacedResolve;
        this.unplacedResolveParams = data.unplacedResolveParams;

        this.onDraw = data.onDraw;
        this.onDrawParams = data.onDrawParams;

        this.burnAfterUse = data.burnAfterUse;

    }*/

}
