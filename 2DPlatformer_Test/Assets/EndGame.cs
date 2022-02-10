using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private bool _endGame = false;
    [SerializeField] private string _finalScene = null;


    private void Update()
    {
        if (_endGame == true)
        {
            CheckEndgame();
        }
    }



    private void CheckEndgame()
    {
        EditorSceneManager.OpenScene(_finalScene);


    }
}
