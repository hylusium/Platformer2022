namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class ChangeRoom : MonoBehaviour
    {
        [SerializeField] private GameObject[] _firstElem = null;
        [SerializeField] private GameObject[] _secondElem = null;
        [SerializeField] private Material _normalMat = null;
        [SerializeField] private Material _glitchMaterial = null;
        private bool _isFirstRoom = true;

        private PlayerController _pcRef = null;


        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
        }

        private void Start()
        {
            for (int i = 0; i < _firstElem.Length; i++)
            {
                _firstElem[i].GetComponentInChildren<Renderer>().material = _normalMat;
                _firstElem[i].GetComponentInChildren<Collider>().enabled = true;

            }
            for (int a = 0; a < _secondElem.Length; a++)
            {
                _secondElem[a].GetComponentInChildren<Renderer>().material = _glitchMaterial;
                _secondElem[a].GetComponentInChildren<Collider>().enabled = false;
            }
        }


        private void OnEnable()
        {
            _pcRef.RightMapPerformed -= _pcRef_RightMapPerformed;
            _pcRef.RightMapPerformed += _pcRef_RightMapPerformed;
            
        }

       

        private void OnDisable()
        {
            _pcRef.RightMapPerformed -= _pcRef_RightMapPerformed;
        }

        private void _pcRef_RightMapPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (_isFirstRoom == true)
            {
                for (int i = 0; i < _firstElem.Length; i++)
                {
                    _firstElem[i].GetComponentInChildren<Renderer>().material = _glitchMaterial;
                    _firstElem[i].GetComponentInChildren<Collider>().enabled = false;
                    

                }
                for (int a = 0; a < _secondElem.Length; a++)
                {
                    _secondElem[a].GetComponentInChildren<Renderer>().material = _normalMat;
                    _secondElem[a].GetComponentInChildren<Collider>().enabled = true;
                }
                _isFirstRoom = false;
            }
            else
            {
                for (int i = 0; i < _firstElem.Length; i++)
                {
                    _firstElem[i].GetComponentInChildren<Renderer>().material = _normalMat;
                    _firstElem[i].GetComponentInChildren<Collider>().enabled = true;

                }
                for (int a = 0; a < _secondElem.Length; a++)
                {
                    _secondElem[a].GetComponentInChildren<Renderer>().material = _glitchMaterial;
                    _secondElem[a].GetComponentInChildren<Collider>().enabled = false;
                }
                _isFirstRoom = true;
            }
           
        }


       
    }

}