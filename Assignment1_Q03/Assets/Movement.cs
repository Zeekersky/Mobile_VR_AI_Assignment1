using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 40;
    public float force = 10;
    public float omega = 45;
    private bool onPlane = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(transform.position, Vector3.up, -omega * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.RotateAround(transform.position, Vector3.up, omega * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && onPlane)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
            onPlane = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Plane")
            onPlane = true;
    }
}
