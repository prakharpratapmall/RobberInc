using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float intervalLower;
    public float intervalUppper;
    public float boundX;
    public float boundY;
    public GameObject collectible;
    void Start()
    {
        Invoke("SpawnObject",Random.Range(intervalLower,intervalUppper));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        Vector3 tmp = new Vector3(Random.Range(-boundX,boundX),Random.Range(-boundY,boundY),0);
        Instantiate(collectible, tmp,transform.rotation);
        Invoke("SpawnObject",Random.Range(intervalLower,intervalUppper));
    }
}
