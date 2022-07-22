using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikan : MonoBehaviour
{
    public Vector2 _targetPos;
    [SerializeField] float _speed;

    private bool isPaused;
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

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;
        Move();
    }

    private void GenerateTargetPos(){
        float xAxis = transform.position.x > 0 ? -10f : 10f;
        _targetPos.x = xAxis;

        float yAxis = Random.Range(-4.5f , 4.5f);
        _targetPos.y = yAxis;

        SpriteRenderer thisSprite = GetComponent<SpriteRenderer>();
        thisSprite.flipX = _targetPos.x > 0 ? false: true;
    }

    private void Move(){
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        Vector2 currentPos = transform.position;
        if(currentPos == _targetPos)
            Destroy(gameObject);
    }
}
