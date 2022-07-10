using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 _targetPos;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTargetPos();
    }

    private void Update() {
        Vector2 currentPos = transform.position;
        if(currentPos.y == -5.5f)
            Destroy(gameObject);
    }

    private void GenerateTargetPos(){
        float xAxis = Random.Range(-6.5f , 6.5f);
        _targetPos.x = xAxis;

        float yAxis = 5.5f;
        _targetPos.y = yAxis;
    }
}
