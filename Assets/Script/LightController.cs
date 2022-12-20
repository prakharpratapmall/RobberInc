using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;
    public float lightSpeed = 0.03f;
    public float bX,bY,iLower,iUpper;
    Vector3 target;
    void Start()
    {
        target = new Vector3(0,0,0);
        Invoke("ChangeDest",1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,lightSpeed);
        Debug.DrawRay(transform.position,target,Color.red);
        transform.position = new Vector3(transform.position.x,transform.position.y,10);
    }
    void ChangeDest()
    {
        target = new Vector3(cam.position.x+Random.Range(-bX,bX),cam.position.y+Random.Range(-bY,bY),0);
        Invoke("ChangeDest",Random.Range(iLower,iUpper));
    }
}
