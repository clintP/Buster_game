using System.Collections;
using UnityEngine;

public class Buster_rotation : MonoBehaviour
{
    public Transform objectToMove;

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
 
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            objectToMove.transform.position = hit.point;
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
