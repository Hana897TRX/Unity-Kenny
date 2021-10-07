using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigidbody;
    SpriteRenderer sr;
    public Sprite kid_fell, kid_normal;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0.0f, 0f, 0.035f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0.0f, 0f, -0.035f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.035f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.035f, 0f, 0f);
            }

            if(Input.GetKey(KeyCode.Space))
            {
                sr.sprite = kid_normal;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        rigidbody.velocity = Vector3.zero;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer == 6)
        {
            sr.sprite = kid_fell;
        }
    }
}
