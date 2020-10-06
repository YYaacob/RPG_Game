using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject invTab;

    void Start()
    {
        invTab.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            invTab.SetActive(true);
        }
        else
        {
            invTab.SetActive(false);
        }
    }
}