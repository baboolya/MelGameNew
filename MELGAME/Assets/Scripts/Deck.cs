using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Source.Scripts.Objects;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cardPrefabs;
    [SerializeField] private Hand _hand;

    [SerializeField] private Canvas _canvas;

    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<Sprite> _secondSprites;
    [SerializeField] private List<Sprite> _thirdSprites;

    [SerializeField] private int _startCardOnLevel;
    [SerializeField] private int _levelCount = 0;

    private List<int> _poolOfValues = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
    private List<string> _poolOfSuit = new List<string>() { "Kr", "By", "Pi", "Ch" };

    private int[] _firstCardOrder = new int[] { 0, 1, 2, 3, 4};
    private int[] _secondCardOrder = new int[] { 0, 14, 15, 29, 30};
    private int[] _thirdCardOrder = new int[] { 0, 13, 26, 29, 42};

    private List<string> _cardsValues = new List<string>();
    private List<Sprite> _defaultSprites = null;

    private List<int> values = new List<int>();
    private List<string> suits = new List<string>();

    private int _trainingLevelCounter = 3;
    private int _handTrainCounter = 3;

    private List<Target> _cards = new List<Target>();

    private int[] _currentOrder;

    private void Start()
    {
        _defaultSprites = _sprites;

        CreateNewDeck();

        SetCardsOnBoard();
    }

    private void Update()
    {
        if(_hand.GetFully())
        {
            foreach (var card in _cardPrefabs)
                card.gameObject.SetActive(false);
        }
    }

    private void Shuffle()
    {
        Target nullCard = null;

        for (int i = 0; i < _cards.Count; i++)
        {
            int randomNumber = Random.Range(0, _cards.Count);

            nullCard = _cards[randomNumber];
            _cards[randomNumber] = _cards[i];
            _cards[i] = nullCard;
        }
    }

    private void SetCardsOnBoard()
    {
        int randomNumberOfCard;
        int currentNumberInOrder;

        switch (_levelCount)
        {
            case 0:
                _currentOrder = _firstCardOrder;
                break;

            case 1:
                _currentOrder = _secondCardOrder;
                break;

            case 2:
                _currentOrder = _thirdCardOrder;
                break;

            default:
                _currentOrder = _firstCardOrder;
                break;
        }

        for (int i = 0; i <= _startCardOnLevel; i++)
        {
            if (_levelCount < _trainingLevelCounter)
            {
                for (int j = 0; j < _currentOrder.Length; j++)
                {
                    currentNumberInOrder = _currentOrder[j];
                    EnableCard(j, currentNumberInOrder);
                }
            }
            else
            {
                EnableCard(i, i);
            }
        }

        if (_levelCount < _trainingLevelCounter)
        {
            for (int i = 0; i < _handTrainCounter; i++)
            {
                _hand.TakeUnitInHand(_cardPrefabs[i].GetComponent<Target>());
                _cardPrefabs[i].gameObject.SetActive(false);
            }
        }
    }

    public void Restart()
    {   
        _levelCount++;
        
        if(_levelCount >= _trainingLevelCounter)
        { 
            Shuffle();
        }

        SetCardsOnBoard();

        if (_levelCount < _trainingLevelCounter)
        {
            for (int i = 0; i < _startCardOnLevel; i++)
            {
                if (i > _handTrainCounter)
                {
                    _cardPrefabs[i].gameObject.SetActive(true);
                    _cardPrefabs[i].GetComponent<Target>().Respawn();
                }
            }
        }
        else
        {
            if(_startCardOnLevel + 1 < _cardPrefabs.Count)
                _startCardOnLevel++;

            for (int i = 0; i < _startCardOnLevel; i++)
            {
                _cardPrefabs[i].gameObject.SetActive(true);
                _cardPrefabs[i].GetComponent<Target>().Respawn();
            }
        }
    }

    private void CreateNewDeck()
    {
        int currentSpriteNumber = 0;

        for (int i = 0; i < _poolOfSuit.Count; i++)
        {
            for (int j = 0; j < _poolOfValues.Count; j++)
            {
                _cards.Add(new Target(_poolOfValues[j], _poolOfSuit[i], _sprites[currentSpriteNumber]));
                currentSpriteNumber++;
            }
        }
    }

    private void EnableCard(int numberOfCard, int numberOfPrefab)
    {
        _cardPrefabs[numberOfCard].gameObject.SetActive(true);

        _cardPrefabs[numberOfCard].GetComponent<Target>().SetValue(_cards[numberOfPrefab].GetValue());
        _cardPrefabs[numberOfCard].GetComponent<Target>().SetSuit(_cards[numberOfPrefab].GetSuit());

        _cardPrefabs[numberOfCard].GetComponent<Target>().SetSprite(_cards[numberOfPrefab].GetSprite());
        _cardPrefabs[numberOfCard].GetComponent<Target>().ConfirmSprite();
    }
}
