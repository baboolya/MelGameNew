using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoChanger : MonoBehaviour
{
    public List<AudioClip> _defaultAudioClips;
    public List<AudioClip> _rareAudioClips;
    public List<AudioClip> _superAudioClips;

    public VideoPlayer _videoPlayer;
    public AudioSource _audio;

    public string backgroundVideoPlayerName;

    public string[] _defaultClipsName;
    public string[] _rareClipsName;
    public string[] _superClipsName;

    private bool _isComplete = false;

    private string[] videoNames = null;
    private List<AudioClip> audioClips = null;

    private void Start()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, backgroundVideoPlayerName);

        _videoPlayer.url = videoPath;

        _videoPlayer.isLooping = true;

        _videoPlayer.Play();
    }

    public void PlayClip(int ratingClip)
    {
        StartCoroutine(PlayRandomVideoClip(ratingClip));
    }

    public bool GetComplete()
    {
        return _isComplete;
    }

    public void Restart()
    {
        _isComplete = false;
    }

    private IEnumerator PlayRandomVideoClip(int ratingClip)
    {
        _isComplete = false;

        int randomIndex;
        string videoPath;

        if(ratingClip == 0)
        {
            if (_defaultClipsName != null)
            {
                videoNames = _defaultClipsName;
                audioClips = _defaultAudioClips;
            }
            else
            {
                yield break;
            }
        }
        else if(ratingClip == 1)
        {
            if (_rareClipsName != null)
            {
                videoNames = _rareClipsName;
                audioClips = _rareAudioClips;
            }
            else
            {
                yield break;
            }
        }
        else if(ratingClip == 2)
        {
            if (_superClipsName != null)
            {
                videoNames = _superClipsName;
                audioClips = _superAudioClips;
            }
            else
            {
                yield break;
            }
        }

        randomIndex = UnityEngine.Random.Range(0, videoNames.Length);

        videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoNames[randomIndex]);
        _audio.clip = audioClips[randomIndex];
                
        _videoPlayer.url = videoPath;

        _videoPlayer.isLooping = false;

        _videoPlayer.Play();
        _audio.Play();
        
        yield return new WaitUntil(() => !_videoPlayer.isPlaying);

        _videoPlayer.isLooping = false;

        videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, backgroundVideoPlayerName);
        _audio.Stop();

        _videoPlayer.url = videoPath;

        _videoPlayer.isLooping = true;
        _videoPlayer.Play();

        _isComplete = true;
    }
}
