using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpawnner : MonoBehaviour
{
    [SerializeField] GameObject[] ObjSpawn;
    [SerializeField] float Timer;
    [SerializeField] Transform currentPos;
    float currentTimer;
    public AudioClip soundSpawn;

    private void Start()
    {
        currentTimer = Timer;
        currentPos.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            GetSpawnObj();
            currentTimer = Timer;
        }
    }

    private void GetSpawnObj()
    {
        int i = Random.Range(0, ObjSpawn.Length);
        float xAxis = Random.Range(-6.5f, 6.5f);
        Vector2 newSpawnPos = new Vector2(xAxis, currentPos.position.y);
        Instantiate(ObjSpawn[i], newSpawnPos, Quaternion.identity);
        AudioManager.instance.PlaySound(soundSpawn);
        return;

    }
}
