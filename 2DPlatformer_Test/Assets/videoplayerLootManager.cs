using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoplayerLootManager : MonoBehaviour
{
    [SerializeField] private GameObject _self = null;
    [SerializeField] private Camera _cameraMain = null;
    [SerializeField] private VideoPlayer _selfVP = null;
    public VideoClip _videoClipPlaying = null;
    [System.NonSerialized] public bool _isHidden = true;



    private void Awake()
    {
        _self.SetActive(false);
    }


    private void Update()
    {
        if (_isHidden == true)
        {
            _self.SetActive(false);
        }
        else
        {
            _self.SetActive(true);
        }
        StopVideoPlayer();
    }

    private void StopVideoPlayer()
    {

        if (_selfVP.clip.frameCount >= _videoClipPlaying.frameCount)
        {
            _selfVP.Stop();
            _videoClipPlaying = null;
            _isHidden = true;
        }


    }
}
