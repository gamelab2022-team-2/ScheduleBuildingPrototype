using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimationController : MonoBehaviour
{
    public Player player;
    public Transform handTransform;

    public void AnimateDraw(Card card)
    {
        switch (card.type)
        {
            case CardType.STUDY:
                break;
            case CardType.STATUS:
                break;
            case CardType.SELFCARE:
                break;
            
        }
    }
}
