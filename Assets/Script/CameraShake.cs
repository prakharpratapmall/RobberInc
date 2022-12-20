using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCam;
    float shakeAmt = 0.01f;
    void Awake()
    {
        if(mainCam==null)
            mainCam = Camera.main;
    }
    public void Shake(float amt, float length)
    {
        shakeAmt = amt;
        InvokeRepeating("BeginShake",0,0.01f);
        Invoke("EndShake",length);
    }
    public void BeginShake()
    {
        if(shakeAmt>0)
        {
            Vector3 camPos = mainCam.transform.position;
            float shakeX = Random.value*shakeAmt*2-shakeAmt;
            float shakeY = Random.value*shakeAmt*2-shakeAmt;
            camPos.x+=shakeX;
            camPos.y+=shakeY;
            mainCam.transform.position = camPos;
        }
    }
    public void EndShake()
    {
        CancelInvoke("BeginShake");
        Vector3 resetCam = new Vector3(0,0,-10);
        mainCam.transform.localPosition = resetCam; 
    }
}
