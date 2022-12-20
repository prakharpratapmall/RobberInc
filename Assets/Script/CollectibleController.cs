using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController pScript;
    bool pickupAllow = false;
    void Start()
    {
        pScript = (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(pickupAllow==true && Input.GetKey("space"))
        {
            pScript.health+=pScript.healAmt;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
            pickupAllow = true;
    }
    void OnTriggerEnter2D(Collider col)
    {
        if(col.gameObject.tag=="Player")
            pickupAllow = false;
    }
}
