using ScriptableObjects;
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
        public GameObject shapeSpawner;
        public CardSpawner cardSpawner;
        public IntegerVariable turn;

        void Start()
        {
            if (cardSpawner == null) cardSpawner = GetComponent<CardSpawner>();
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

        //returns all cards to the off screen "cardSleeve" location in the discard or resolve phase
        /*public void ReturnAllToSleeve()
        {
            for (int i = 0; i < _player.hand.Count; i++)
            {
                _player.hand.GetAtIndex(i).gameObject.transform.position = cardSpawner.CardSleeve.transform.position;
            }

            shapeSpawner.GetComponent<ShapeSpawner>().Clear();
        }*/
        
        //TODO: function to reset the game

    }
}
