using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;

public class Plane : MonoBehaviour
{
    [SerializeField] private GameObject _plane = null;
    [SerializeField] private CubeController _playerRef = null;
    [SerializeField] private bool _isItFirst = false;

    private void Awake()
    {
        if (_isItFirst == true)
        {
            _plane.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {
            _plane.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<CubeController>())
        {
            _plane.SetActive(false);
        }
    }




}
