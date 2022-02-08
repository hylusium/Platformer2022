using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using GSGD2.Utilities;
using GSGD2.Gameplay;

public class unlockDash : MonoBehaviour
{
    [SerializeField] CubeController _cubecontroller = null;
    [SerializeField] RewindTime _rewind = null;
    [SerializeField] ChangeRoom _changeroom = null;
    [SerializeField] private bool _dash = false;
    [SerializeField] private bool _wallGrab = false;
    [SerializeField] private bool _rewindTime = false;
    [SerializeField] private bool _changeRoom = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {

            if (_dash == true)
            {
                _cubecontroller._dash.enabled = true;

            }
            else if (_wallGrab == true)
            {
                _cubecontroller._enableWallGrab = true;
            }
            else if (_rewindTime == true)
            {
                _rewind.enabled = true;
            }
            else if (_changeroom == true)
            {
                _changeroom.enabled = true;
            }
        }
    }
}
