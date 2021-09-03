using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //this.transform.Translate(Vector3.forward * Time.deltaTime);
            transform.Translate(0.0f, 0f, 0.03f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //this.transform.Translate(Vector3.back * Time.deltaTime);
            transform.Translate(0.0f, 0f, -0.03f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //this.transform.Rotate(Vector3.up, -2); 360 degrees movement
            transform.Translate(-0.03f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.Rotate(Vector3.up, 2);
            transform.Translate(0.03f, 0f, 0f);
        }
    }
}
