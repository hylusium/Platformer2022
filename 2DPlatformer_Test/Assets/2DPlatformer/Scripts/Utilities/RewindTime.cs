namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RewindTime : MonoBehaviour
    {

        #region variables

        [SerializeField] private int _arrayLength = 5;
        [SerializeField] private float _duration = 0;
        [SerializeField] private List<Vector3> _debugArray = null;
       

        private bool coroutinesOver = true;
        private int _arrayMinusOne;
        private int _arrayIndex = 0;

        #endregion variables

        private void Start()
        {
            // List<Part> parts = new List<Part>();
            List<Vector3> _lastKnownLocation = new List<Vector3>();
            UpdatePos(_lastKnownLocation);
            _arrayMinusOne = _arrayLength - 1;
        }

        public List<Vector3> UpdatePos(List<Vector3> Vector)
        {
            Debug.Log("Ouais la zone");
            if (Vector.Count >= _arrayLength)
            {
                Debug.Log("Test");
                Vector.RemoveAt(0);
                Vector.Add(this.transform.position);
            }
            else
            {
                Vector.Add(this.transform.position);
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
            Vector3[] tempTransform = _debugArray.ToArray();

            //for (int i = 0; i < _arrayMinusOne; i++)
            //{

            //}

            for (int i = 0; i < tempTransform.Length; i++)
            {
                Debug.LogFormat("{0}, : valeur du tableau", tempTransform.GetValue(i));
            }
            foreach (Vector3 item in tempTransform)
            {
                if (_arrayIndex < _arrayMinusOne)
                {
                    MoveToNextWaypoint(item);
                    _arrayIndex++;
                }
            }
            //tempTransform = null;
            _debugArray.Clear();
        }

        private void MoveToNextWaypoint(Vector3 nextWaypoint)
        {
            // Find Direction : direction = targetPosition - selfPosition;
            transform.position += (nextWaypoint - transform.position);
        }
    }
}

