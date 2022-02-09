using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPickup : MonoBehaviour
{
    [System.NonSerialized] public int _count = 0;


    public void AddValue(int value)
    {

        _count += value;

    }
    private void Update()
    {
        Debug.Log(_count);
    }
}
