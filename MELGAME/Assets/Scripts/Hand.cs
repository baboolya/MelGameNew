using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Source.Scripts.Objects;
using TMPro;

public class Hand : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();

    [SerializeField] private Score _score;
    [SerializeField] private Deck _deck;

    [SerializeField] private VideoChanger _videoChanger;

    [SerializeField] private TMP_Text _scoreAdd;
    [SerializeField] private TMP_Text _combinationText;

    [SerializeField] private RewManager _rewManager;

    private List<Target> _hand = new List<Target>();
    private List<Target> _nullhand = new List<Target>();

    private List<int> handValues = new List<int>();
    private List<string> handSuits = new List<string>();

    private bool _isReadyToEvaluade = false;
    private bool _isRewTaked = false;
    private int _clipRating = 0;
    private string _winScoreAdd;  
    private string _winCombo;  

    private int _fullHandCounter = 5;
    private int _currentNumberOfCard = 0;

    private void Update()
    {
        if (_videoChanger.GetComplete())
        {
            _winCombo = "Ничего!";

            _deck.Restart();
            _videoChanger.Restart();
            _winScoreAdd = " ";

            foreach (var card in _images)
                card.gameObject.SetActive(false);
        }

        if (_isReadyToEvaluade)
        {
            _currentNumberOfCard = 0;

            EvaluateHand();
            _isReadyToEvaluade = false;

            _hand.Clear();
            handSuits.Clear();
            handValues.Clear();

            _videoChanger.PlayClip(_clipRating);

            _clipRating = 0;            
        }
        else
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                _images[i].gameObject.SetActive(true);
            }

            EvaluateHand();
            _scoreAdd.text = _winScoreAdd;
            _combinationText.text = _winCombo;
        }
    }

    public void TakeUnitInHand(Target target)
    {      
        if (_hand.Count < _fullHandCounter)
        {
            if(CanTakeMore())
            {
                _hand.Add(target);

                _images[_currentNumberOfCard].gameObject.SetActive(true);
                _images[_currentNumberOfCard].sprite = _hand[_currentNumberOfCard].GetSprite();

                handValues.Add(target.GetValue());
                handSuits.Add(target.GetSuit());

                _currentNumberOfCard++;
            }
        }        
    }

    public bool CanTakeMore()
    {
        bool isAbleToTake = false;

        if (_hand.Count < _fullHandCounter)
        {            
            isAbleToTake = true;
        }

        return isAbleToTake;
    }

    private void EvaluateHand()
    {
        int currentCombination;

        bool hasPair = false;
        bool hasTwoPairs = false;
        bool hasThreeOfAKind = false;
        bool hasStraight = false;
        bool hasFlush = false;
        bool hasFullHouse = false;
        bool hasFourOfAKind = false;
        bool hasStraightFlush = false;

        Dictionary<int, int> cardValueCounts = new Dictionary<int, int>();

        for (int i = 0; i < handValues.Count; i++)
        {
            if (cardValueCounts.ContainsKey(handValues[i]))
            {
                cardValueCounts[handValues[i]]++;
            }
            else
            {
                cardValueCounts.Add(handValues[i], 1);
            }
        }

        foreach (var count in cardValueCounts.Values)
        {
            if (count == 2)
            {
                if (hasPair)
                {
                    hasTwoPairs = true;
                }

                if (hasThreeOfAKind)
                {
                    hasFullHouse = true;
                }

                hasPair = true;
            }
            else if (count == 3)
            {
                if (hasPair)
                {
                    hasFullHouse = true;
                }

                hasThreeOfAKind = true;
            }
            else if (count == 4)
            {
                hasFourOfAKind = true;
            }
        }

        hasStraight = CheckOnStraight();
        hasFlush = CheckIfAllEqual(handSuits);

        if (hasStraight && hasFlush)
        {
            hasStraightFlush = true;
            _clipRating = 2;
        }

        if (hasStraightFlush)
        {
            SetRewardForCombination(2, 20000, "Стрит-Флеш!");
        }
        else if (hasFourOfAKind)
        {
            SetRewardForCombination(2, 12000, "Каре!");
        }
        else if (hasFullHouse)
        {
            SetRewardForCombination(2, 12000, "Фулл-хаус!");
        }
        else if (hasFlush)
        {
            SetRewardForCombination(2, 10000, "Флеш!");
        }
        else if (hasStraight)
        {
            SetRewardForCombination(2, 6500, "Стрит!");
        }
        else if (hasThreeOfAKind)
        {
            SetRewardForCombination(1, 5000, "Сет!");
        }
        else if (hasTwoPairs)
        {
            SetRewardForCombination(1, 2000, "Две пары!");
        }
        else if (hasPair)
        {
            SetRewardForCombination(1, 1000, "Пара!");
        }
        else
        {
            _clipRating = 0;
        }
    }

    private bool CheckIfAllEqual(List<string> cardsSuits)
    {
        if (cardsSuits.Count != 5)
        {
            return false; 
        }

        string firstCardSuit = cardsSuits[0]; 

        for (int i = 1; i < cardsSuits.Count; i++)
        {
            if (cardsSuits[i] != firstCardSuit)
            {
                return false; 
            }
        }

        return true; 
    }

    private bool CheckOnStraight()
    {
        int[] intArray = new int[_hand.Count];
        bool isValid = true;

        for (int i = 0; i < _fullHandCounter; i++)
        {
            if (_hand.Count == _fullHandCounter)
                intArray[i] = _hand[i].GetComponent<Target>().GetValue();
            else
                isValid = false;
        }

        Array.Sort(intArray);

        for (int i = 0; i < intArray.Length - 1; i++)
        {
            if (Math.Abs(intArray[i] - intArray[i + 1]) != 1 && !(i == intArray.Length - 2 && Math.Abs(intArray[i] - intArray[i + 1]) == intArray.Length - 1))
            {
                isValid = false;
                break;
            }
        }

        return isValid;
    }

    public bool GetFully()
    {
        if (CanTakeMore() == false)
        {
            _isReadyToEvaluade = true;
        }

        return CanTakeMore() == false;
    }

    private void SetRewardForCombination(int clipRating, int score, string winText)
    {
        if (_isReadyToEvaluade)
        {
            _clipRating = clipRating;
            _score.AddScore(score);

            if (!_isRewTaked)
                _winScoreAdd = $"+ {score} $";
            else
                _winScoreAdd = $"+ {score} $ x2";

            _isReadyToEvaluade = false;
        }
        else
        {
            if (!_isRewTaked)
                _winScoreAdd = $"+ {score} $";
            else
                _winScoreAdd = $"+ {score} $ x2";

        }

        _winCombo = winText;
    }
}
