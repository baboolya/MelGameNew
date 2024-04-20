using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;
using Agava.YandexMetrica;
using TMPro;

public class RewManager : MonoBehaviour
{
    public bool _isUnity;
    public int _restartTimer;

    public Button _rewButton;

    public Action RewardTaked;

    private Action _adOpenedToImage;
    private Action _rewardAdClosedToImage;
    private Action _adOpenedToReborn;
    private Action _rewardAdClosedToReborn;

    private Action _getReward;
    private Action<string> _adErrorMessage;

    private bool _isRewardTaken;
    private int _currentTimer;

    protected void OnEnable()
    {
        if(!_isUnity)
            YandexMetrica.Send("GameStart");
        
        _adOpenedToImage += OnAdOpenedToImage;
        _rewardAdClosedToImage += OnRewardAdCloseToImage;        
    }

    protected void OnDisable()
    {
        _adOpenedToImage -= OnAdOpenedToImage;
        _rewardAdClosedToImage -= OnRewardAdCloseToImage;
    }

    public void PlayRewAdToImage()
    {
        if (!_isUnity)
        {
            YandexMetrica.Send("PlayRewAdToImage");

            VideoAd.Show(OnAdOpenedToImage, GetRewardToImage, OnRewardAdCloseToImage, OnErrorCallBackToImage);
        }

        Debug.Log("AD");
    }

    private void GetRewardToImage()
    {
        YandexMetrica.Send("GetRewardToImage");

        _rewButton.interactable = false;

        _isRewardTaken = true;
        RewardTaked?.Invoke();

        _isRewardTaken = false;
    }

    private void OnAdOpenedToImage()
    {
        Debug.Log("Open");

        AudioListener.pause = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;

        Debug.Log("Paused");
    }

    private void OnRewardAdCloseToImage()
    {
        Debug.Log("Close");

        AudioListener.pause = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;

        Debug.Log("UnPaused");
    }

    private void OnErrorCallBackToImage(string String)
    {
        Debug.Log(String);
    }
}
