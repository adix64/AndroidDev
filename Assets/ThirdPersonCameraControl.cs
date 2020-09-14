using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    public Transform player;
    float yaw = 0, pitch = 0;
    public float distToTarget = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = -Input.GetAxis("Mouse Y");

        yaw += mx;
        pitch += my;

        pitch = Mathf.Clamp(pitch, -45, 45); //limiteaza intre -45 si 45

        transform.rotation = Quaternion.Euler(pitch, yaw, 0); // unghiurile cu axele principale
        transform.position = player.position // de la pozitia playerului
                            - transform.forward * distToTarget; // ne dam in spate
    }
}
