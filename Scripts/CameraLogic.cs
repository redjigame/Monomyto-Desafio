
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;//vitesse de la camera

    private float height = 20f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        Movecam();


    }//Update

    private void Movecam()
    {
        Vector3 pos = new Vector3();

        pos.x = player.position.x;
        pos.z = player.position.z - 1f;//proximité max de la cam from the player
        pos.y = player.position.y + height;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }//Movecam


}
