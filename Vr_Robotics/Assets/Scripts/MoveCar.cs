using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public GameObject parent;
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

    public void MoveForward(int val)
    {
        carRB.velocity = transform.forward * val;
    }

    public void MoveBackward(int val)
    {
        carRB.velocity = -transform.forward * val;
    }

    public void RotateLeft(int val)
    {
        parent.transform.Rotate(Vector3.up * carSpeed * Time.deltaTime);
        //Vector3 oldpos = transform.position;
        //transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + 90f, transform.localRotation.eulerAngles.z);
        //transform.position = oldpos;
    }

    public void RotateRight(int val)
    {
        parent.transform.Rotate(Vector3.up * carSpeed * Time.deltaTime);
        //Vector3 oldpos = transform.position;
        //transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y - 90f, transform.localRotation.eulerAngles.z);
        //transform.position = oldpos;
    }

    // Update is called once per frame
    void Update()
    {
        //parent.transform.Rotate(Vector3.up * carSpeed * Time.deltaTime);
        //Vector3 oldpos = parent.transform.position;
        //parent.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + 90f, transform.localRotation.eulerAngles.z);
        //parent.transform.position = oldpos;
    }
}
