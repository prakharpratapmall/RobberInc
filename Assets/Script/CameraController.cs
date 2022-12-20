using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float cameraSpeed = 0.03f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position,cameraSpeed*Time.deltaTime);
        transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }
}
