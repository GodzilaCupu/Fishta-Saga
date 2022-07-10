using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBrust : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    SpriteRenderer sr;
    BoxCollider2D bc;
    bool once = true;
    public GameObject effect;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.tag == "Player")
        // {
        //     collisionParticleSystem.Play();
        //     Invoke(nameof(DestroyObj), 0.5f);
        //     // print("Masuk");
        //     sr.enabled = false;
        //     bc.enabled = false;
        //     // StartCoroutine(Break());

        //     // Destroy(gameObject);
        // }

        if (other.gameObject.CompareTag("Player") && once)
        {
            Instantiate(effect,transform.position,Quaternion.identity);
            // print("Masuk");
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(sr);
            Invoke(nameof(DestroyObj), dur);
        }

    }

    IEnumerator Break()
    {
        collisionParticleSystem.Play();

        sr.enabled = false;
        bc.enabled = false;

        yield return new WaitForSeconds(collisionParticleSystem.main.startLifetime.constantMax);

        Destroy(gameObject);

    }

    // void OnTriggerEnter2D(Collider2D coll)
    // {
    //     if (coll.gameObject.CompareTag("Player") && once)
    //     {
    //         print("Mausk");
    //         var em = collisionParticleSystem.emission;
    //         var dur = collisionParticleSystem.duration;

    //         em.enabled = true;
    //         collisionParticleSystem.Play();

    //         once = false;
    //         Destroy(sr);
    //         // Invoke(nameof(DestroyObj), dur);
    //     }
    // }


    void DestroyObj()
    {
        Destroy(gameObject);
    }

}
