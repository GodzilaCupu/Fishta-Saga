 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundHandler : MonoBehaviour
{
    private SpriteRenderer targetSprite;
    [SerializeField] private Sprite[] assetSprite;

    private void Start()
    {
        targetSprite = GetComponent<SpriteRenderer>();
        CheckSprite(Database.GetProgress("Map"));
    }

    private void CheckSprite(int idSprite)
    {
        targetSprite.sprite = assetSprite[idSprite];
        if( idSprite == 1)
        {
            Vector3 newScale = new Vector3(1.1f, 1.4f, 1f);
            this.gameObject.transform.localScale = newScale;
        }
    }
}
