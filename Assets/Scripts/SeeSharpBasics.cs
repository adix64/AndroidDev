using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSharpBasics : MonoBehaviour
{  //data_type    //varName
    int            myInt = -1;

    float          myFloat = 3.14f;

    string         myString = "sirulM3uDeC@ract3r3";

    bool myBool = true, myOtherBool = false;

    int[] intArray;

    class MyType
    {
       public int membru1, membru2;
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(Time.time);
        transform.position = new Vector3(0, y, 0);

        bool conditie = true;
        if (conditie)
        {
            int i = 1;
        }
        else
        {
            int i = 2;
        }
    }
}
