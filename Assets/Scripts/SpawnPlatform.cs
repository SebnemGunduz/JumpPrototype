using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject> Platformlist = new List<GameObject>();
    public float SpawnTime;
    private float SpawnCountTime;
    private Vector3 spawnPosition;
    public float ySpeed = 1f; 




    void Start()
    {

    }

    
    void Update()
    {
        
        transform.position += new Vector3(0, ySpeed * Time.deltaTime, 0);
        SpawnPlatformer();
    }


    public void SpawnPlatformer()
    {
         SpawnCountTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-2.1f,2.18f);

        if(SpawnCountTime >= SpawnTime) {

            PlatformApperance();
            SpawnCountTime= 0;



             }
    }


    public void PlatformApperance () {  
        int index = Random.Range(0, Platformlist.Count);    
        Instantiate(Platformlist[index],spawnPosition,Quaternion.identity);
}
}

