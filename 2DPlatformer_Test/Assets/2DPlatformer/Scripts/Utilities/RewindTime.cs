namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RewindTime : MonoBehaviour
    {

        #region variables

        [SerializeField]
        private int _arrayLength = 0;

        [SerializeField]
        private Transform[] debugArray = null;
        // Transform Array for Rewind Get a value Of 5
        //




        #endregion variables


        private void Start()
        {
            Transform[] _lastknownLocation = new Transform[_arrayLength];

            debugArray = _lastknownLocation;
        }



        private void Update()
        {

        }

        private void AddTransformToList()
        {




        }









    }






}

