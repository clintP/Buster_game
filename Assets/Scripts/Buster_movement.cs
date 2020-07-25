using System.Collections;
using UnityEngine;

public class Buster_movement : MonoBehaviour
{
    public Vector2 movement_vector;
    public Vector2 mouse_position;
    public Vector2 buster_position;
    private float movement_distance;
    private float speed = 2.0f;
    private float deadzone = 3.5f;
    private float mouse_vel_sensitivity = 2.0f;
    private float smooth = 5.0f;
    private float tiltAngle = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey( KeyCode.LeftArrow ))
        {
            Buster_RotateLeft();
        }

        if(Input.GetKey( KeyCode.RightArrow ))
        {
            Buster_RotateRight();
        }

        // Get mouse input coordinates
        mouse_position = Input.mousePosition;
        // Transform mouse coordinates to world coordinates
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);
        buster_position = transform.position;
        movement_vector = (mouse_position - buster_position).normalized;
        // Translates Buster if he is outside of the deadzone
        if((mouse_position-buster_position).magnitude > deadzone)
        {
            // Translation
            transform.Translate(movement_vector * Time.deltaTime * speed * (mouse_position-buster_position).magnitude);

            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundX = Input.GetAxis("Mouse X") * tiltAngle;
            float tiltAroundY = Input.GetAxis("Mouse Y") * tiltAngle;

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, 0);
            // Dampen towards the target rotation
            Quaternion Buster_rotation_3D = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
            Quaternion Buster_rotation_2D = Quaternion.Euler(new Vector3(0f, 0f, Buster_rotation_3D.eulerAngles.z));
            transform.rotation = Buster_rotation_2D;
            //transform.Rotate((Vector3.forward * mouse_vel_sensitivity * -Input.GetAxis("Mouse X")) - );
        }

    }
    
    // Rotates Buster when left is pressed
    void Buster_RotateLeft()
    {
        transform.Rotate(Vector3.forward * -1);
    }

    // Rotates Buster when left is pressed
    void Buster_RotateRight()
    {
        transform.Rotate(Vector3.forward * 1);
    }
}
