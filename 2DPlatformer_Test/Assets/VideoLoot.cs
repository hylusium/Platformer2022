using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using GSGD2.Player;

//            __,__
//   .--.  .- "     " -. .--.
//  / .. \/  .-. .-.  \/ ..  \
// | |  '|  /   Y   \  |'  | |
// | \   \  \ 0 | 0 /  /   / |
//  \ '- ,\.-"`` ``"-./, -' /
//   `'-' / _ ^ ^_\    '-'`
//       |  \._ _./    |
//       \   \ `~` /   /
//        '._ '-=-' _.'
//           '~---~'


// .-----------------. .----------------.  .----------------. 
//| .--------------. || .--------------. || .--------------. |
//| | ____  _____  | || |  _________   | || |  _________   | |
//| ||_   \|_   _| | || | |_   ___  |  | || | |  _   _  |  | |
//| |  |   \ | |   | || |   | |_  \_|  | || | |_/ | | \_|  | |
//| |  | |\ \| |   | || |   |  _|      | || |     | |      | |
//| | _| |_\   |_  | || |  _| |_       | || |    _| |_     | |
//| ||_____|\____| | || | |_____|      | || |   |_____|    | |
//| |              | || |              | || |              | |
//| '--------------' || '--------------' || '--------------' |
// '----------------'  '----------------'  '----------------' 




public class VideoLoot : MonoBehaviour
{
    public VideoClip _videoToPlay = null;
    [SerializeField] private videoplayerLootManager _playerVideoManager = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {
            _playerVideoManager._videoClipPlaying = _videoToPlay;
            
            Destroy(this.gameObject);

        }

    }









}
