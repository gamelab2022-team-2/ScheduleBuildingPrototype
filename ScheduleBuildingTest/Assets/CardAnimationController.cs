using DG.Tweening;
using UnityEngine;

public class CardAnimationController : MonoBehaviour
{
    public Transform handTransform, deckTransform, discardTransform, focusTransform, cardSleeveTransform;
    public float drawDuration = 0.2f;
    public AudioManager audio;

    public Tween AnimateDraw(Card card, int handSlot = 0)
    {
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(PlayDrawCardSound);
        switch (card.type)
        {
            case CardType.STATUS:
                sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration)).SetEase(Ease.InOutSine);
                sequence.Append(card.transform.DOMove(focusTransform.position, 0.5f)).SetEase(Ease.InOutSine);

                if (card.burnAfterUse)
                {
                    sequence.Append(card.transform.DOShakePosition(1, drawDuration).SetEase(Ease.InOutSine));
                    sequence.Append(card.transform.DOMove(cardSleeveTransform.position, drawDuration)
                        .SetEase(Ease.InOutSine));
                }
                else
                {
                    sequence.Append(card.transform.DOMove(discardTransform.position, drawDuration)
                        .SetEase(Ease.InOutSine));
                }

                return sequence;
            default:

                sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration)).SetEase(Ease.InOutSine);
                sequence.Append(card.transform.DOMove(handTransform.GetChild(handSlot).position, drawDuration)
                    .SetEase(Ease.InOutSine));
                return sequence;
        }
    }

    public Tween Shuffle(Card card)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(card.transform.DOShakePosition(.05f).SetEase(Ease.InOutSine));
        sequence.Append(card.transform.DOShakeRotation(.05f, 1).SetEase(Ease.InOutSine));

        return sequence;
    }

    public Tween ToDeck(Card card)
    {
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(PlayDrawCardSound);
        sequence.Append(card.transform.DOMove(deckTransform.position, drawDuration).SetEase(Ease.InOutSine));
        return sequence;
    }

    public Tween ToDiscard(Card card, int position)
    {
        var sequence = DOTween.Sequence();
        sequence.AppendCallback(PlayDiscardCardSound);
        sequence.Append(card.transform
            .DOMove(discardTransform.position - Vector3.forward * position * 0.3f, drawDuration)
            .SetEase(Ease.InOutSine));
        return sequence;
    }

    public Tween RemoveFromDiscard(Card card)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(card.transform.DOMove(focusTransform.position, drawDuration / 2)).SetEase(Ease.InOutSine);
        sequence.Append(card.transform.DOMove(focusTransform.position, 0.5f)).SetEase(Ease.InOutSine);
        sequence.Append(card.transform.DOShakePosition(1, drawDuration / 4).SetEase(Ease.InOutSine));
        sequence.Append(card.transform.DOMove(cardSleeveTransform.position, drawDuration / 2).SetEase(Ease.InOutSine));
        return sequence;
    }

    public void PlayRandomCardSound()
    {
        var rand = Random.Range(0f, 1f);
        if (rand < 0.5f)
            audio.PlaySingleSound("CardDeal");
        else
            audio.PlaySingleSound("Discard");
    }

    public void PlayDrawCardSound()
    {
        audio.PlaySingleSound("CardDeal");
    }

    public void PlayDiscardCardSound()
    {
        audio.PlaySingleSound("Discard");
    }

    public void PlayShuffleSound()
    {
        var rand = Random.Range(0f, 1f);
        if (rand < 0.5f)
            audio.PlaySingleSound("CardDeal");
        else
            audio.PlaySingleSound("Discard");
    }
}