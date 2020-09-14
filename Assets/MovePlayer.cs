using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speedMultiplier = 1f;
    public float xCtrl, zCtrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 offset = xCtrl * Camera.main.transform.right +
                         zCtrl * Camera.main.transform.forward; // in spatiul camera

        offset.y = 0;
        offset = offset.normalized; // aducem la lungime unitate

        offset *= Time.deltaTime; // deplasamentul proportional cu timpul scurs intre 2 cadre
        
        transform.position += offset * speedMultiplier; // deplasament per frame
    }
}
