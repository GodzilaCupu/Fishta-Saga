using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFromPlayer : MonoBehaviour
{
    // public static ParticleFromPlayer instance;
    // public GameObject effect;
    public ParticleSystem particle;
    bool once = true;

    void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ikan_Kecil"))
        {
            // Instantiate(effect, transform.position, Quaternion.identity);
            // print("Masuk");
            var em = particle.emission;
            var dur = particle.duration;

            em.enabled = true;
            particle.Play();

            once = false;
        }
    }

    public void PlayParticle()
    {
        // Instantiate(effect, transform.position, Quaternion.identity);
        // var em = particle.emission;
        // var dur = particle.duration;

        // em.enabled = true;
        // particle.Play();

        // once = false;

    }
}
