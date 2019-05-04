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

    void MoveForward(int val)
    {
        carRB.velocity = transform.forward * val;
    }

    void MoveBackward(int val)
    {
        carRB.velocity = -transform.forward * val;
    }

    void RotateLeft(int val)
    {
        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * val, Space.World);
    }

    void RotateRight(int val)
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * val, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
