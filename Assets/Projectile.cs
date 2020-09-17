using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile este scriptul de pe obiectul instantiat cu GameObject.Instantiate
public class Projectile : MonoBehaviour
{
    public Vector3 direction; // setat din exterior la instantiere

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * 30f; // actualizam pozitia proiectilului
    }
}