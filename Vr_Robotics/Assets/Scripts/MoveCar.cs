using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    GameObject car;
    Vector3 move;
    Rigidbody carRB;
    public float carSpeed;

    private void OnEnable()
    {
        //this.MoveForward();
    }

    // Start is called before the first frame update
    void Start()
    {
        car = this.gameObject;
        carRB = this.GetComponent<Rigidbody>();
        move = this.gameObject.transform.position;
    }

    void MoveForward()
    {
        carRB.velocity = transform.forward * carSpeed;
    }

    void MoveBackward()
    {
        carRB.velocity = -transform.forward * carSpeed;
    }

    void RotateLeft()
    {
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * carSpeed, Space.World);
    }

    void RotateRight()
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * carSpeed, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.MoveForward();
        }
    }
}
