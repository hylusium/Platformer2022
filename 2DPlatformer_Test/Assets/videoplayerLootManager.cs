using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using GSGD2.Player;

public class videoplayerLootManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController = null;
    [SerializeField] private GameObject _self = null;
    [SerializeField] private VideoPlayer _selfVP = null;
    
    public VideoClip[] _videoClipPlaying;
   
    [System.NonSerialized] public bool _isHidden = true;
    [System.NonSerialized] public int Index = 0;
    
    private MeshRenderer _meshRenderer = null;

    private void Awake()
    {
        _meshRenderer = _self.GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
        _selfVP.loopPointReached -= _selfVP_loopPointReached;
        _selfVP.loopPointReached += _selfVP_loopPointReached;
    }

    private void _selfVP_loopPointReached(VideoPlayer source)
    {
        StopVideoPlayer();
    }

    private void Update()
    {
        if (_selfVP.isPlaying == false && _isHidden == false)
        {
            _meshRenderer.enabled = true;
            PlayVideo();
        }
    }

    private void StopVideoPlayer()
    {
        _selfVP.Stop();
        _meshRenderer.enabled = false;
        _selfVP.clip = null;
        _isHidden = true;
        _playerController.enabled = true;
    }

    private void PlayVideo()
    {
        _selfVP.clip = _videoClipPlaying[Index];

        if (_selfVP.waitForFirstFrame)
        {
            _selfVP.Play();
            _playerController.enabled = false;
        }
    }

    private void OnDestroy()
    {
        _selfVP.loopPointReached -= _selfVP_loopPointReached;
    }
}

