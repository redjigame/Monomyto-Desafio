
using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    CharacterController characterController;
    Camera camera;

    private Vector3 move_Direction;

    private float currentSpeed;
    private float walkSpeed = 3f;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        camera = GetComponentInParent<Camera>();
    }

    private void Start()
    {
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
        RotateTowardMouseCursor();

    }

    private void Movement()
    {
        move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= currentSpeed * Time.deltaTime;

        characterController.Move(move_Direction);
    }

    void RotateTowardMouseCursor()
    {
        //Player facing mouse init
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15f * Time.deltaTime);
        }//Player facing mouse end
    }


}
