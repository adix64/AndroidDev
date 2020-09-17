using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speedMultiplier = 1f;
    public float xCtrl, zCtrl;
    Animator animator;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 offset = (x + xCtrl) * Camera.main.transform.right +
                         (z + zCtrl) * Camera.main.transform.forward; // din spatiul camera in spatiul lume

        offset.y = 0; // aducem in plan orizontal offsetul
        offset = offset.normalized; // aducem la lungime unitate

        Vector3 characterSpaceVelocity = transform.InverseTransformDirection(offset); // trecem din spatiul lume in spatiul personaj
        //setam parametrii animatorului, case sensitive, ca in Animator din editor:
        animator.SetFloat("VelocityX", characterSpaceVelocity.x);
        animator.SetFloat("VelocityZ", characterSpaceVelocity.z);

        offset *= Time.deltaTime; // deplasamentul proportional cu timpul scurs intre 2 cadre
        
        transform.position += offset * speedMultiplier; // deplasament per frame

        if (Input.GetKeyDown(KeyCode.Space))
            InstantiateNewObj();
    }

    void InstantiateNewObj()
    {
        GameObject go = GameObject.Instantiate(projectilePrefab); // cloneaza obiectul prefab in scena(ierarhie)
        Projectile projectile = go.GetComponent<Projectile>(); // referentiem scriptul Projectile
        go.transform.position = transform.position; // setam pozitia proiectilului la pozitia personajului
        projectile.direction = Camera.main.transform.forward; // setam directia de deplasare a proiectilului
    }
}
