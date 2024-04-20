using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Agava.YandexGames;
using Agava.YandexMetrica;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scorePlace;
    [SerializeField] private TMP_Text _dutyText;

    [SerializeField] private bool _isUnity;
    [SerializeField] private RewardTimer _rewardTimer;
    [SerializeField] private int _dutyValue;

    private int _score;
    private bool _isRewardTaked;

    private void OnEnable()
    {
        _rewardTimer.RewardTaked += OnRewardTaked;
        _rewardTimer.TimerComplited += OnTimerComplite;
    }

    private void OnDisable()
    {
        _rewardTimer.TimerComplited -= OnTimerComplite;
    }

    private void Start()
    {
        if (!_isUnity)
        {
            if (PlayerPrefs.HasKey("Score"))
                _score = PlayerPrefs.GetInt("Score");
            else
                _score = 0;
        }
        else
        {
            _score = 0;
        }

        _scorePlace.text = _score.ToString() + "$";

        if (!_isUnity)
            PlayerPrefs.SetInt("Score", _score);
    }



    public void AddScore(int value)
    {
        if (!_isUnity)
        {
            YandexMetrica.Send("LvlComplite");

            if (PlayerPrefs.HasKey("Score"))
                _score = PlayerPrefs.GetInt("Score");
            else
                _score = 0;
        }

        if (_score + value <= int.MaxValue)
        {
            if (_isRewardTaked)
                value *= 2;

            _score += value;

            if (_score >= _dutyValue)
            {
                _dutyText.gameObject.SetActive(false);
                _scorePlace.color = new Color(145f / 255f, 255f / 255f, 0f / 255f);
            }

            int _currentDutyValue = _dutyValue - _score;

            _dutyText.text = $"ƒŒÀ√: {_currentDutyValue}$";
            _scorePlace.text = _score.ToString() + "$";
        }
        else
        {
            _score = int.MaxValue;
            _scorePlace.text = "›“Œ Ã¿ —»Ã”Ã!";
        }

        if (!_isUnity)
        {
            PlayerPrefs.SetInt("Score", _score);
            PlayerPrefs.Save();
        }
    }

    private void OnRewardTaked()
    {
        _isRewardTaked = true;
    }

    private void OnTimerComplite()
    {
        _isRewardTaked = false;
    }
}
