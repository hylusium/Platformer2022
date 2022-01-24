namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class LoadScene : MonoBehaviour
    {

        [SerializeField]
        private LoadSceneComponent _loadscenecomponent = null;

       

        private bool isPlayerColliding = false;



        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<CubeController>())
            {
               
                isPlayerColliding = true;
            }
        }

        private void Update()
        {
            if (isPlayerColliding == true)
            {

            }
        }


    }

}