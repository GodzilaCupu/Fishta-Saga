using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 _targetPos;
    private bool isPaused;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTargetPos();
        EventManager.current.onOpenPaused += () => isPaused = true;
        EventManager.current.onClosePaused += () => isPaused = false;
    }

    private void OnDisable()
    {
        EventManager.current.onOpenPaused -= () => isPaused = true;
        EventManager.current.onClosePaused -= () => isPaused = false;
    }

    private void Update() 
    {
        if (isPaused)
        {
            rb.simulated = false;
            return;
        }
        Vector2 currentPos = transform.position;
        rb.simulated = true;
        if (currentPos.y == -5.5f)
            Destroy(gameObject);
    }

    private void GenerateTargetPos(){
        float xAxis = Random.Range(-6.5f , 6.5f);
        _targetPos.x = xAxis;

        float yAxis = 5.5f;
        _targetPos.y = yAxis;

        rb = GetComponent<Rigidbody2D>();
    }
}
