namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using GSGD2.Utilities;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu = null;
        [SerializeField] private CubeController _cubeController = null;
        [SerializeField] private RewindTime rewindRef = null;
        [SerializeField] private ChangeRoom roomRef = null;
        private PlayerController _pcRef = null;
        private bool _isFirstTime = true;
        private float _tempVelocity = 0;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
            _pauseMenu.SetActive(false);
           _tempVelocity = _cubeController._groundMoveSpeed;
            
        }

        private void OnEnable()
        {
            _pcRef.PauseMenuPerformed -= _pcRef_PauseMenuPerformed;
            _pcRef.PauseMenuPerformed += _pcRef_PauseMenuPerformed;
        }
        private void OnDisable()
        {
            _pcRef.PauseMenuPerformed -= _pcRef_PauseMenuPerformed;
        }

        public void Pause()
        {
            if (_isFirstTime == true)
            {
                _pauseMenu.SetActive(true);
                _isFirstTime = false;
                _cubeController._groundMoveSpeed = 0;
                _cubeController._jump.enabled = false;
                _cubeController._dash.enabled = false;
                rewindRef.enabled = false;
                roomRef.enabled = false;
            }
            else
            {
                _pauseMenu.SetActive(false);
                _isFirstTime = true;
                _cubeController.enabled = true;
                _cubeController._groundMoveSpeed = _tempVelocity;
                _cubeController._jump.enabled = true;
                _cubeController._dash.enabled = true;
                rewindRef.enabled = true;
                roomRef.enabled = true;
            }


        }


        private void _pcRef_PauseMenuPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Pause();
        }
    }

}