namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RewindTime : MonoBehaviour
    {

        #region variables


        [SerializeField] private float _refreshVectorDuration = 0;
        [SerializeField] private float _rewindCooldown = 0;
        [SerializeField] private Vector3 Vector3Debug;
        [SerializeField] private GameObject RewindPreview = null;



        private bool coroutinesOver = true;
        private bool cooldownOver = true;


        #endregion variables

        private void Start()
        {
            RewindPreview.transform.position = transform.position;
            UpdatePos(transform.position);

        }

        public Vector3 UpdatePos(Vector3 Vector)
        {
            Debug.Log(Vector);

            coroutinesOver = true;
            Vector3Debug = Vector;
            RewindPreview.transform.position = Vector3Debug;
            RewindPreview.SetActive(true);
            return Vector3Debug;


        }

        private void Update()
        {
            AddTransformToList();
            if (Input.GetKeyDown(KeyCode.B) && cooldownOver == true)
            {
                RewindAction();
                StartCoroutine(RewindCoolDown(_rewindCooldown));
                
            }
        }

        private void AddTransformToList()
        {
            StartCoroutine(PositionCD(_refreshVectorDuration));
        }

        IEnumerator PositionCD(float duration)
        {
            if (coroutinesOver == true)
            {
                coroutinesOver = false;
                yield return new WaitForSeconds(duration);
                UpdatePos(transform.position);
            }
        }

        IEnumerator RewindCoolDown(float duration)
        {
            if (cooldownOver == true)
            {
                cooldownOver = false;
                yield return new WaitForSeconds(duration);
                cooldownOver = true;

            }

        }

        private void RewindAction()
        {
            MoveToNextWaypoint(Vector3Debug);
        }

        private void MoveToNextWaypoint(Vector3 nextWaypoint)
        {
            // Find Direction : direction = targetPosition - selfPosition;
            transform.position = nextWaypoint;
            RewindPreview.SetActive(false);
        }
    }
}

