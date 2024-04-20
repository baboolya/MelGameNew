using System;
using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexMetrica;
using TMPro;

public class InterTimer : MonoBehaviour
{
    [SerializeField] private bool _isUnity;

    [SerializeField] private float _waitTime;
    [SerializeField] private int _adsTimer;

    [SerializeField] private GameObject _adsPannel;

    private TMP_Text _textMessage;

    private bool _isFirstAd;
    private int _currentTimer;
    private Coroutine _changer;
    private float _sendTimer = 1f;
    private float _maxTime = 105f;
    private float _currentSendTimer;

    private Action _adOpened;
    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorMessage;

    private void Start()
    {
        _textMessage = _adsPannel.GetComponentInChildren<TMP_Text>();

        _changer = StartCoroutine(ChangeText());
        _currentTimer = _adsTimer;

        _isFirstAd = true;
        StartCoroutine(Timer());

        if (!_isUnity)
            YandexMetrica.Send("StartAd");
    }

    private void OnEnable()
    {
        _adOpened += OnAdOpened;
        _interstitialAdClose += OnInterstitialAdClose;
    }

    private void OnDisable()
    {
        _adOpened -= OnAdOpened;
        _interstitialAdClose -= OnInterstitialAdClose;
    }

    private IEnumerator Timer()
    {
        float adsTime = _waitTime - _adsTimer;

        var waitForAnyMinutes = new WaitForSeconds(adsTime);

        while (true)
        {
            if (adsTime < _maxTime)
            {
                adsTime += 5f;
            }

            if(!_isUnity)
                YandexMetrica.Send("ShowAd");

            if (_isFirstAd == false)
            {
                _adsPannel.SetActive(true);

                yield return ChangeText();
            }
            else
            {
                _isFirstAd = false;
            }

            if (!_isUnity)
                InterstitialAd.Show(onOpenCallback: OnAdOpened, onCloseCallback: OnInterstitialAdClose);

            Debug.Log("Inter");

            _adsPannel.SetActive(false);

            yield return waitForAnyMinutes;
        }
    }

    private void OnAdOpened()
    {
        Time.timeScale = 0f;
    }

    private void OnInterstitialAdClose(bool result)
    {
        Time.timeScale = 1f;
    }

    private IEnumerator ChangeText()
    {
        bool isOpen = true;

        while (isOpen)
        {
            _textMessage.text = $"До начала рекламы {_currentTimer} сек...";

            yield return new WaitForSeconds(1f);

            _currentTimer--;

            if (_currentTimer == 0)
            {
                _currentTimer = _adsTimer;
                isOpen = false;
            }
        }

        if (_changer != null)
        {
            isOpen = true;
            StopCoroutine(_changer);
        }
    }
}