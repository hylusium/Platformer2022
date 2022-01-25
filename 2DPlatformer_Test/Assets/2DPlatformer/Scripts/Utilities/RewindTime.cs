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


        [SerializeField]
        private List<Transform> _debugArray = null;
        private bool coroutinesOver = true;
        private int _arrayMinusOne;

        [SerializeField] private float _rewindSpeed = 5f;

        


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
                Vector.RemoveAt(4);
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

            _debugArray.Reverse();
            //foreach (Transform item in _debugArray)
            //{



            //    transform.position += item.position;
            //        Debug.Log("lerp");


            //}
            //boucle for si ça marche pas 
               
            for (int i = 0; i < _debugArray.Count ; i++)
            {
            }
            _debugArray.Clear();

        }



    }

}

