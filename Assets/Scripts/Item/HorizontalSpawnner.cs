using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawnner : MonoBehaviour
{   
    [SerializeField] GameObject[] ObjSpawn;
    [SerializeField] float Timer;
    [SerializeField] Transform currentPos;
    float currentTimer;
    
    private void Start() {
        currentTimer = Timer;
        currentPos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0){
            currentTimer -= Time.deltaTime;
        }
        else{
            GetSpawnObj();
            currentTimer = Timer;
        }
    }

    private void GetSpawnObj(){
        int i = Random.Range(0,ObjSpawn.Length);
        Instantiate(ObjSpawn[i],currentPos.position, Quaternion.identity);
    }
}
