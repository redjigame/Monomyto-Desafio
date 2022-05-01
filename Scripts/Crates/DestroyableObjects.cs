
using UnityEngine;

public class DestroyableObjects : MonoBehaviour
{
    private MeshRenderer renderer;
    private BoxCollider boxCollider;
    private float health = 1f;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Mort();
        }
    }


    void Mort()
    {
        renderer.enabled = false;
        boxCollider.enabled = false;
        Player.score += 10;
    }
}
