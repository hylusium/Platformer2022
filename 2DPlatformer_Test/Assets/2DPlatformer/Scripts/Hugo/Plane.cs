using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;

public class Plane : MonoBehaviour
{
    [SerializeField] private Transform _instantiatePoint = null;
    [SerializeField] private GameObject _plane = null;
    [SerializeField] private CubeController _playerRef = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {
            Instantiate(_plane, _instantiatePoint);
        }
    }






}
