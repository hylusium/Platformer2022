using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using GSGD2.Player;

//             __,__
//   .--.  .- "     " -. .--.
//  / .. \/  .-. .-.  \/ ..  \
// | |  '|  /   Y   \  |'  | |
// | \   \  \ 0 | 0 /  /   / |
//  \ '- ,\.-"`` ``"-./, -' /
//   `'-' / /_ ^ ^_ \  \ '-'`
//       |  \._  _. /  |
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
    [SerializeField] private videoplayerLootManager _playerVideoManager = null;
    [SerializeField] private CountPickup _pickUpCount = null;
    
    public int Index = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {
            _playerVideoManager._isHidden = false;
            _playerVideoManager.Index = Index;
            _pickUpCount.AddValue(1);

            Destroy(this.gameObject);

        }

    }









}
