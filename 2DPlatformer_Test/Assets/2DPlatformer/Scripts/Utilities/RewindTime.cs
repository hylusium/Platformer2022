namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class RewindTime : MonoBehaviour
    {

        #region variables


        [SerializeField] private float _refreshVectorDuration = 0;
        [SerializeField] private float _rewindCooldown = 0;
        [SerializeField] private Vector3 Vector3Debug;
        [SerializeField] private GameObject RewindPreview = null;


        private PlayerController _pcRef = null;

        private bool coroutinesOver = true;
        private bool cooldownOver = true;


        #endregion variables
        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
        }
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

        private void OnEnable()
        {
            _pcRef.RewindPerformed -= _pcRef_RewindPerformed;
            _pcRef.RewindPerformed += _pcRef_RewindPerformed;
        }
        private void OnDisable()
        {
            _pcRef.RewindPerformed -= _pcRef_RewindPerformed;
        }

        private void _pcRef_RewindPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (cooldownOver == true)
            {
                RewindAction();
                StartCoroutine(RewindCoolDown(_rewindCooldown));
            }
            
        }
    }
}

