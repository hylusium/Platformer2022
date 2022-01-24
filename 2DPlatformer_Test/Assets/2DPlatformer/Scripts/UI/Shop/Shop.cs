using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI _text = null;

    UnityEvent ShowShopMessage;

    private void Start()
    {
        //_text.enabled = false;
        if (ShowShopMessage == null)
        {

            ShowShopMessage = new UnityEvent();


        }
        ShowShopMessage.AddListener(ShowShop);
    }



    public void ShowShop()
    {
        //_text.enabled = true;
        Debug.Log("shop sensor");



    }



}
