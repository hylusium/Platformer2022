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
        private Transform[] _debugArray = null;
        // Transform Array for Rewind Get a value Of 5
        //




        #endregion variables


        private void Start()
        {
            Transform[] _lastknownLocation = new Transform[_arrayLength];

            UpdatePos(_lastknownLocation);
            
        }


        public Transform[] UpdatePos(Transform[] Vector)
        {

            _debugArray = Vector;
            return Vector;
        }



        private void Update()
        {
            
        }

        private void AddTransformToList()
        {




        }









    }






}

