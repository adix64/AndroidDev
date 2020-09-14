using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public Transform cutie;
    Vector3 initPos;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        initPos = cutie.transform.position;
        rigidBody = cutie.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropObject()
    {
        rigidBody.useGravity = true;
    }

    public void ResetPosition()
    {
        rigidBody.useGravity = false;
        rigidBody.position = initPos;
    }

}
