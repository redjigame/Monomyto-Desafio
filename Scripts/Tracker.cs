
using UnityEngine;

public class Tracker : MonoBehaviour
{
    Transform player;

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            this.transform.parent = player.transform;
            this.transform.position = player.transform.position;
        }
    }
}
