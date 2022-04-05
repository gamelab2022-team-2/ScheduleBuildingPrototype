using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType  {STUDY, SELFCARE, STATUS };

[CreateAssetMenu(fileName = "New Card ", menuName = "Card")]

public class CardData : ScriptableObject
{

    // played variables
    public string shape;
    public Color shapeColor;

    public int cardArtIndex;

    public int cardId;

    public CardType type;

    public string cardName;

    public Sprite shapeImage;
    public Color cardColor;

    [TextArea]
    public string cardDescription;
    [TextArea]
    public string onPlayDescription;
    [TextArea]
    public string unplayedDescription;
    [TextArea]
    public string statusDescription;
    [TextArea]
    public string flavorText;

    public List<string> placedResolve;
    public List<int> placedResolveParams;

    public List<string> unplacedResolve;
    public List<int> unplacedResolveParams;

    public List<string> onDraw;
    public List<int> onDrawParams;

    public bool burnAfterUse;

    public int topLeftValue;
    public int bottomLeftValue;
    public int bottomRightValue;
    public int topRightValue;




}
