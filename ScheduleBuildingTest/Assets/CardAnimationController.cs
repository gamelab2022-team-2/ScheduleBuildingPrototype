using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardAnimationController : MonoBehaviour
{
    public Transform handTransform, deckTransform, discardTransform, focusTransform, cardSleeveTransform;
    public float drawDuration = 0.2f;
    

    public Tween AnimateDraw(Card card,int handSlot = 0)
    {
        switch (card.type)
        {
            case CardType.STATUS:
                Sequence sequence = DOTween.Sequence();
                sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration)).SetEase(Ease.InOutSine);
                sequence.Append(card.transform.DOMove(focusTransform.position, 1f)).SetEase(Ease.InOutSine);
                
                if (card.burnAfterUse)
                {
                    sequence.Append(card.transform.DOShakePosition(1, 3));
                }
                else
                    sequence.Append(card.transform.DOMove(discardTransform.position, drawDuration));

                return sequence;
            default:
                return card.transform.DOMove(handTransform.GetChild(handSlot).position, drawDuration).SetEase(Ease.InOutSine);
        }
    }

    public Tween Shuffle(Card card)
    {

        Sequence sequence = DOTween.Sequence();
        sequence.Append(card.transform.DOShakePosition(.05f, 1).SetEase(Ease.InOutSine));
        sequence.Append(card.transform.DOShakeRotation(.05f, 1).SetEase(Ease.InOutSine));

        return sequence;

    }

    public Tween ToDeck(Card card)
    {
        return card.transform.DOMove(deckTransform.position, 0.3f).SetEase(Ease.InOutSine);
    }

    public Tween ToDiscard(Card card)
    {
        return card.transform.DOMove(discardTransform.position, 0.05f).SetEase(Ease.InOutSine);
    }
    
    
}
