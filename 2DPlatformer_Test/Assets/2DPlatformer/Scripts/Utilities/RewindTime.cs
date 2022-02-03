namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class RewindTime : MonoBehaviour
    {

        #region variables


        [SerializeField] private Vector3 Vector3Debug;
        [SerializeField] private GameObject RewindPreview = null;
        [SerializeField] private float _distanceTreshold = 0;
        [SerializeField] private PlayerReferences _playerReference = null;

        [SerializeField]
        private Timer _timer = null;
        private int _listLength = 50;
        private CharacterCollision _characterCollision = null;
        public List<Vector3> _rewindPos = new List<Vector3>();
        private float _tempDistance;



        private PlayerController _pcRef = null;



        #endregion variables
        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _pcRef);
        }
        private void Start()
        {
            RewindPreview.transform.position = transform.position;
            _rewindPos.Add(transform.position);
        }

        private void Update()
        {
            AddTransformToList();
        }

        private void AddTransformToList()
        {
            //bool timerReady = _timer.Update();
            //bool isOnGround = _characterCollision.CheckGround();
            //bool isFarEnough = Vector3.Distance(transform.position, _rewindPos[_rewindPos.Count - 1]) > _distanceTreshold;
            //if (timerReady && isOnGround && isFarEnough)
            //{
            //    _rewindPos.Add(transform.position);

            //    if (_rewindPos.Count > _listLength)
            //    {
            //        _rewindPos.RemoveAt(0);
            //    }
            //    _timer.Start();
            //}

            if (_timer.Update() == true)
            {
                if (_characterCollision.CheckGround() == true)
                {

                    if (Vector3.Distance(transform.position, _rewindPos[_rewindPos.Count - 1]) > _distanceTreshold)
                    {
                        _rewindPos.Add(transform.position);

                        if (_rewindPos.Count > _listLength)
                        {
                            _rewindPos.RemoveAt(0);
                        }

                    }

                }
                _timer.Start();
            }

        }

        private void RewindAction()
        {
            for (int i = _rewindPos.Count - 1; i >= 0; i--)
            {
                _tempDistance = Vector3.Distance(transform.position, _rewindPos[i]);
                if (_tempDistance > _distanceTreshold)
                {
                    Debug.Log("rewind");
                    transform.position = _rewindPos[i];
                    _rewindPos.Clear();
                    _rewindPos.Add(transform.position);
                    break;
                }

            }
        }



        private void OnEnable()
        {
            _pcRef.RewindPerformed -= _pcRef_RewindPerformed;
            _pcRef.RewindPerformed += _pcRef_RewindPerformed;
            _playerReference.TryGetCharacterCollision(out _characterCollision);
            _timer.Start();
        }
        private void OnDisable()
        {
            _pcRef.RewindPerformed -= _pcRef_RewindPerformed;
            _timer.Stop();
        }

        private void _pcRef_RewindPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {


            RewindAction();



        }
    }
}

