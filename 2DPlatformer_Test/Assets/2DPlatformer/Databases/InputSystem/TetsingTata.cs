namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class TetsingTata : MonoBehaviour
    {
        [SerializeField]
        private InputActionMapWrapper _inputActionMap = null;
        private InputAction _pauseMenuInputAction = null;


        [SerializeField] private GameObject _pauseMenu = null;
        private PlayerController _pcRef = null;
        private bool _isFirstTime = true;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
            _pauseMenu.SetActive(false);
        }

        private void OnEnable()
        {

            if (_inputActionMap.TryFindAction("PauseMenu", out InputAction _pauseMenuInputAction) == true)
            {
                _pauseMenuInputAction.performed -= _pauseMenuInputAction_performed;
                _pauseMenuInputAction.performed += _pauseMenuInputAction_performed;

            }

        }

        private void _pauseMenuInputAction_performed(InputAction.CallbackContext obj)
        {
            Pause();
        }

        private void OnDisable()
        {
            _pauseMenuInputAction.performed -= _pauseMenuInputAction_performed;

            _pauseMenuInputAction.Disable();

        }


        private void Pause()
        {
            if (_isFirstTime == true)
            {
                _pauseMenu.SetActive(true);
                _isFirstTime = false;
                _pcRef.enabled = false;
            }
            else
            {
                _pauseMenu.SetActive(false);
                _isFirstTime = true;
                _pcRef.enabled = true;
            }


        }




    }
}

