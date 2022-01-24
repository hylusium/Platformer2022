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
        private InputAction _abilityImproverInteractionInputAction = null;

        private void OnEnable()
        {
            if (_inputActionMap.TryFindAction("AbilityUpgrade", out InputAction _abilityImproverInteractionInputAction) == true)
            {

                _abilityImproverInteractionInputAction.performed -= _abilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.performed += _abilityImproverInteractionInputAction_performed;

                _abilityImproverInteractionInputAction.Enable();
            }

        }


        private void OnDisable()
        {
            _abilityImproverInteractionInputAction.performed -= _abilityImproverInteractionInputAction_performed;

            _abilityImproverInteractionInputAction.Disable();

        }





        private void _abilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            
        }

    }
}

