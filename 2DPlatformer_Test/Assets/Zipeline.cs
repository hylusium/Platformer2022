namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class Zipeline : MonoBehaviour
    {
        [SerializeField]
        private Transform _entryPoint = null;
        [SerializeField]
        private Transform _exitPoint = null;
        [SerializeField]
        private Transform _playerpos = null;
        [SerializeField]
        private float speed = 0.5f;

        
        private float startTime;
        private float journeyLength;



        private void Start()
        {
            
            startTime = Time.deltaTime;

            
            journeyLength = Vector3.Distance(_playerpos.position, _exitPoint.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<CubeController>())
            {
                LerpPlayer();
            }


        }



        private void LerpPlayer()
        {
            float distCovered = (Time.time - startTime) * speed;
            Debug.Log(distCovered);

            float fractionOfJourney = distCovered / journeyLength;

            _playerpos.position = Vector3.Lerp(_playerpos.position, _exitPoint.position, fractionOfJourney);


        }


    }





}