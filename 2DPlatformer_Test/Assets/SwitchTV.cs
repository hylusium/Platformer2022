using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;

public class SwitchTV : MonoBehaviour
{

    [SerializeField] private Transform _exitPoint = null;
    [SerializeField] private Transform _playerRef = null;


    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponentInParent<CubeController>())
        {

            _playerRef.position = _exitPoint.transform.position;
            _playerRef.rotation = _exitPoint.transform.rotation;
        }
    }

}
