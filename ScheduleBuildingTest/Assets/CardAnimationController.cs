using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardAnimationController : MonoBehaviour
{
    public Transform handTransform, deckTransform, discardTransform, focusTransform, cardSleeveTransform;
    public float drawDuration = 0.2f;


    public Tween AnimateDraw(Card card, int handSlot = 0)
    {
        Sequence sequence = DOTween.Sequence();
        switch (card.type)
        {
            case CardType.STATUS:
                sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration)).SetEase(Ease.InOutSine);
                sequence.Append(card.transform.DOMove(focusTransform.position, 1f)).SetEase(Ease.InOutSine);

                if (card.burnAfterUse)
                {
                    sequence.Append(card.transform.DOShakePosition(1, drawDuration).SetEase(Ease.InOutSine));
                    sequence.Append(card.transform.DOMove(cardSleeveTransform.position, drawDuration).SetEase(Ease.InOutSine));
                }
                else
                    sequence.Append(card.transform.DOMove(discardTransform.position, drawDuration).SetEase(Ease.InOutSine));

                return sequence;
            default:

                sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration)).SetEase(Ease.InOutSine);
                sequence.Append(card.transform.DOMove(handTransform.GetChild(handSlot).position, drawDuration).SetEase(Ease.InOutSine));
                return sequence;
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
        return card.transform.DOMove(deckTransform.position, drawDuration).SetEase(Ease.InOutSine);
    }

    public Tween ToDiscard(Card card)
    {
        return card.transform.DOMove(discardTransform.position, drawDuration).SetEase(Ease.InOutSine);
    }


}
