using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    Image backgound;
    [SerializeField] SpriteRenderer spriteRendererBG;

    public Sprite[] sprites;
    int randomBackground;

    // Start is called before the first frame update
    void Start()
    {
        randomBackground = Random.Range(0, sprites.Length);
        spriteRendererBG.sprite = sprites[randomBackground];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
