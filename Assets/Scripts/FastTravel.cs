using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class FastTravel : MonoBehaviour
{
    public GameObject travelCamera;
    public GameObject fastTravelUI;
    GameObject player;

    public Transform[] travelPos;

    ThirdPersonUserControl charControl;

    void Start()
    {
        travelCamera.SetActive(false);
        fastTravelUI.SetActive(false);
        player = GameObject.FindWithTag("Player");
        charControl = player.GetComponent<ThirdPersonUserControl>();
    }

    void OnTriggerEnter(Collider plyr)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if(plyr.tag == "Player")
        {
            fastTravelUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        fastTravelUI.SetActive(false);
    }

    public void TravelTo(int posIndex)
    {
        travelCamera.SetActive(true);
        charControl.enabled = false;
        player.transform.position = travelPos[posIndex].position;
        StartCoroutine("Loading");
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(5);
        charControl.enabled = true;
        travelCamera.SetActive(false);
    }
}
