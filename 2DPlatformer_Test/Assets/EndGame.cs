using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private bool _endGame = false;
    [SerializeField] private string _finalScene = "";
    [SerializeField] private CountPickup _count = null;


    private void Update()
    {
        if (_endGame == true)
        {
            CheckEndgame();
        }
    }



    private void CheckEndgame()
    {
        if (_count._count == 8)
        {
            EditorSceneManager.OpenScene(_finalScene);

        }


    }
}
