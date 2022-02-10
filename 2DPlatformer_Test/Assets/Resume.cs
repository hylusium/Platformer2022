using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject _ui = null;
    private bool _isResume = true;


    private void Update()
    {
        if (_isResume == true)
        {
            _ui.SetActive(true);
        }
        else if (_isResume == false)
        {
            _ui.SetActive(false);
        }
    }


    public void SetResumeState()
    {
        if (_isResume == true)
        {
            _isResume = false;
        }
        else if (_isResume == false)
        {
            _isResume = true;
        }


    }

}
