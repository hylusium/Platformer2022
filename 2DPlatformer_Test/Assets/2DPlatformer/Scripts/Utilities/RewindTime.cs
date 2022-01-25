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
        // Transform Array for Rewind Get a value Of 5
        [SerializeField]
        private Transform[] _debugArray = null;

        [SerializeField]
        private Transform _self = null;

        private int _rewindIndex = 0;
        private Transform _transformTemp;

        

        #endregion variables


        private void Start()
        {
            Transform[] _lastknownLocation = new Transform[_arrayLength];
            
            UpdatePos(this.transform);
           _transformTemp = (Transform)_debugArray.GetValue(0);
            
        }


        public Transform[] UpdatePos(Transform Vector)
        {
            _debugArray.SetValue(Vector);

            return _debugArray;
        }



        private void Update()
        {
            
        }

        private void AddTransformToList()
        {
            



        }









    }






}

