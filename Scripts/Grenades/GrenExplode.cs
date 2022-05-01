
using UnityEngine;

public class GrenExplode : MonoBehaviour
{
    private float delay = 3f;
    private float radius = 15f;
    private float force = 700f;
    private float damage = 25f;

    public GameObject explosEffect;
    // public AudioSource exploSound;

    float countDown;
    bool hasExploded = false;

    void Start()
    {
        countDown = delay;
    }


    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }//Update

    void Explode()
    {
        Instantiate(explosEffect, transform.position, transform.rotation);
        //exploSound.Play();

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            DestroyableObjects destroyable = nearbyObject.GetComponent<DestroyableObjects>();
            if (destroyable != null)
            {
                destroyable.TakeDamage(damage);
            }

            EnemyAI enemy = nearbyObject.GetComponent<EnemyAI>();
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }//ForEach

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }//Explode

}
