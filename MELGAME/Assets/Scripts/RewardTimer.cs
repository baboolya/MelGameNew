using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardTimer : MonoBehaviour
{
    [SerializeField] private RewManager _rewManager;
    [SerializeField] private Button _rewButton;
    [SerializeField] private Score _score;

    [SerializeField] private int _restartTimer;
    [SerializeField] private TMP_Text _timerText;

    public Action TimerComplited;
    public Action RewardTaked;

    private int _currentTimer;

    private void OnEnable()
    {
        _rewManager.RewardTaked += OnRewardTaked;
    }

    private void OnRewardTaked()
    {
        RewardTaked?.Invoke();

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        bool isOpen = true;

        _currentTimer = _restartTimer;

        while (isOpen)
        {
            _rewButton.interactable = false;
            _timerText.text = _currentTimer.ToString();

            _currentTimer--;

            if (_currentTimer == 0)
            {
                _rewButton.interactable = true;
                _currentTimer = _restartTimer;
                _timerText.text = "2X";

                TimerComplited?.Invoke();

                isOpen = false;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
