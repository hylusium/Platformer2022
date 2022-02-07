namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu = null;
        private PlayerController _pcRef = null;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
            _pauseMenu.SetActive(false);
        }


    }

}