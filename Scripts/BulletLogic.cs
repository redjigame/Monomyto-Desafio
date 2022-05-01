
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float speed = 100f;

    private void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position += transform.forward * Time.deltaTime * 100f;
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>())
        {
            other.gameObject.GetComponentInParent<Player>().RpcTakeDamage(0.1f, "bot");
            Destroy(gameObject, 0.1f);
        }
    }
}
