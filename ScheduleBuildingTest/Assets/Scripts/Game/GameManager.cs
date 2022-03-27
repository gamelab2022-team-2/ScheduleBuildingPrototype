using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        private static GameManager _instance;

        public static GameManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion Singleton

        [SerializeField] private Player _player;

        public List<CardData> allCardData;
        
        private GameObject cardSleeve;

        public GameObject shapeSpawner;

        public GameObject gridObjectPrefab;
        public CardSpawner cardSpawner;

        public int turn;

        void Start()
        {
            if (cardSpawner == null) cardSpawner = GetComponent<CardSpawner>();
            turn = 0;
            GenerateCardSets();
        }

        //Creates card game objects and adds them to the "cardSleeve", which is a deck of cards off screen. Adds the card data to each card, then asks the player to draw the first 10
        public void GenerateCardSets()
        {
            foreach (CardData c in allCardData)
            {
                var card = cardSpawner.SpawnCard(c);
                _player.allCards.Add(card);
            }

            _player.GetOpeningDeck();
        }

        //gets the 5 cards that should already be in the player's hand, and moves them from the offscreen "cardSleeve" to in front of the camera. also spawns the shapes on top of the cards
        public void DisplayCardsInHand()
        {
            for (int i = 0; i < _player.hand.Count; i++)
            {
                Card currCard = _player.hand.GetAtIndex(i);
                currCard.gameObject.transform.position = _player.handGO.transform.GetChild(i).position + Vector3.up;
                var shape = Instantiate(gridObjectPrefab);

                shape.GetComponent<GridObject>().init(currCard.cardData.shape,
                    _player.handGO.transform.GetChild(i).position + 2 * Vector3.up, currCard.cardData.shapeColor);
                //shapeSpawner.GetComponent<ShapeSpawner>().SpawnShape(_player.handGO.transform.GetChild(i).position, currCard.cardData.shape, currCard.cardData.shapeColor);
                _player.gridObjects.Add(shape.GetComponent<GridObject>());
            }
        }

        //returns all cards to the off screen "cardSleeve" location in the discard or resolve phase
        public void ReturnAllToSleeve()
        {
            for (int i = 0; i < _player.hand.Count; i++)
            {
                _player.hand.GetAtIndex(i).gameObject.transform.position = cardSpawner.CardSleeve.transform.position;
            }

            shapeSpawner.GetComponent<ShapeSpawner>().Clear();
        }


    }
}
