using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    Transform L, R, F, B;
    // Start is called before the first frame update
    void Start()
    {
        L = transform.GetChild(0);
        R = transform.GetChild(1);
        F = transform.GetChild(2);
        B = transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");// -1 daca e apasat A, 1 daca e apasat D, 0 altfel
        float z = Input.GetAxis("Vertical"); //  -1 daca e apasat S, 1 daca e apasat W, 0 altfel

        L.gameObject.SetActive(x < 0);
        R.gameObject.SetActive(x > 0);
        F.gameObject.SetActive(z > 0);
        B.gameObject.SetActive(z < 0);
    }
}
