namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RewindTime : MonoBehaviour
    {

        #region variables


        [SerializeField]
        private int _arrayLength = 5;


        [SerializeField]
        private float _duration = 0;
        [SerializeField] private float _rewindSpeed = 5f;
        [SerializeField] private int _destinationTreshold = 2;


        [SerializeField] private int _arrayLength = 5;
        [SerializeField] private float _duration = 0;
        [SerializeField] private float _rewindSpeed = 5f;
        [SerializeField] private List<Transform> _debugArray = null;


        private Transform[] tempTransfoArray;

        private bool coroutinesOver = true;
        private int _arrayMinusOne;

        private int _arrayIndex = 0;





        #endregion variables


        private void Start()
        {
            // List<Part> parts = new List<Part>();
            List<Transform> _lastKnownLocation = new List<Transform>();
            UpdatePos(_lastKnownLocation);
            _arrayMinusOne = _arrayLength - 1;
        }


        public List<Transform> UpdatePos(List<Transform> Vector) 
        {
            Debug.Log("Ouais la zone");
            if (Vector.Count >= _arrayLength)
            {
                Debug.Log("Test");
                Vector.RemoveAt(_arrayMinusOne);
                Vector.Add(this.transform);
            }
            else
            {
                Vector.Add(this.transform);
            }
            coroutinesOver = true;
            _debugArray = Vector;

            return _debugArray;
        }

        private void Update()
        {

            AddTransformToList();
            if (Input.GetKeyDown(KeyCode.B))
            {
                RewindAction();
            }

        }

        private void AddTransformToList()
        {
            StartCoroutine(PositionCD(_duration));
        }

        IEnumerator PositionCD(float duration)
        {
            if (coroutinesOver == true)
            {
                coroutinesOver = false;
                yield return new WaitForSeconds(duration);
                UpdatePos(_debugArray);


            }
        }






        private void RewindAction()
        {

            Transform[] tempTransform = _debugArray.ToArray();
            for (int i = 0; i < _arrayMinusOne; i++)
            {

                if (_arrayIndex < _arrayMinusOne)
                {
                    MoveToNextWaypoint(tempTransform[_arrayIndex].position);
                    Debug.Log(_arrayIndex);
                    _arrayIndex++;
                    //testdebug
                }


            _debugArray.Reverse();
            tempTransfoArray = _debugArray.ToArray();
            

            for (int i = 0; i < tempTransfoArray.Length -1; i++)
            {
                tempTransfoArray.GetValue(i);

            }
            _debugArray.Clear();

        }



        private void MoveToNextWaypoint(Vector3 nextWaypoint)
        {
            // Find Direction : direction = targetPosition - selfPosition;
            transform.position += (nextWaypoint - transform.position) * _rewindSpeed * Time.deltaTime;
            
        }

       


    }
}

