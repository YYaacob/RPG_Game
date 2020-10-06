using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    Animator anim;
    //Inventory inventory;

    public bool money;
    public int moneyAmount;
    Currency moneyScript;

    bool pickedUp = false;


    // Use this for initialization
    void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        moneyScript = GameObject.FindWithTag("GameController").GetComponent<Currency>();
    }

    void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !pickedUp)
            {
                pickedUp = true;
                StartCoroutine("PlayAnim");
            }
        }
    }

    IEnumerator PlayAnim()
    {
        anim.SetTrigger("pickup");
        yield return new WaitForSeconds(1);
        if (money)
        {
            moneyScript.gold += moneyAmount;
            Destroy(gameObject);
        }
        
    }
}