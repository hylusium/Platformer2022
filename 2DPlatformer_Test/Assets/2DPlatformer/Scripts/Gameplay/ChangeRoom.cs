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

        private PlayerController _pcRef = null;


        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
        }

        private void Start()
        {
            for (int i = 0; i < _firstElem.Length; i++)
            {
                _firstElem[i].SetActive(true);
                _secondElem[i].SetActive(false);
            }
        }


        private void OnEnable()
        {
            _pcRef.RightMapPerformed -= _pcRef_RightMapPerformed;
            _pcRef.RightMapPerformed += _pcRef_RightMapPerformed;
            _pcRef.LeftMapPerformed -= _pcRef_LeftMapPerformed;
            _pcRef.LeftMapPerformed += _pcRef_LeftMapPerformed;
        }

       

        private void OnDisable()
        {
            _pcRef.RightMapPerformed -= _pcRef_RightMapPerformed;
            _pcRef.LeftMapPerformed -= _pcRef_LeftMapPerformed;
        }

        private void _pcRef_RightMapPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            for (int i = 0; i < _firstElem.Length; i++)
            {
                _firstElem[i].SetActive(true);
                _secondElem[i].SetActive(false);
            }
        }


        private void _pcRef_LeftMapPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            for (int i = 0; i < _firstElem.Length; i++)
            {
                _firstElem[i].SetActive(false);
                _secondElem[i].SetActive(true);
            }
        }
    }

}