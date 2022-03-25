using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType  {STUDY, SELFCARE, STATUS };

[CreateAssetMenu(fileName = "New Card ", menuName = "Card")]

public class CardData : ScriptableObject
{

    // played variables
    public string shape;
    public Color shapeColor;

    public int cardId;

    public CardType type;

    public string cardName;

    [TextArea]
    public string cardDescription;

    public List<string> placedResolve;
    public List<int> placedResolveParams;

    public List<string> unplacedResolve;
    public List<int> unplacedResolveParams;

    public List<string> onDraw;
    public List<int> onDrawParams;

    public bool burnAfterUse;




}
