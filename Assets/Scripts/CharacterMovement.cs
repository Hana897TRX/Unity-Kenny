using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigidbody;
    SpriteRenderer sr;
    public Sprite kid_fell, kid_normal, SW, SS, SA, SD, SSpace;
    public GameObject keyUI;
    bool shouldaMove;
    public bool automove;

    public float kidVelocity = 0.015F;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        shouldaMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            KeyCode key = KeyCode.None;

            if(keyUI != null)
            {
                keyUI.GetComponent<Image>().enabled = true;
            }


            if (automove)
            {
                transform.Translate(0.0f, 0f, kidVelocity);
            }

            if (Input.GetKey(KeyCode.W) && shouldaMove)
            {
                key = KeyCode.W;
                keyUI.GetComponent<Image>().sprite = SW;
                transform.Translate(0.0f, 0f, kidVelocity);
            }

            if (Input.GetKey(KeyCode.S) && shouldaMove)
            {
                key = KeyCode.S;
                keyUI.GetComponent<Image>().sprite = SS;
                transform.Translate(0.0f, 0f, -kidVelocity);
            }

            if (Input.GetKey(KeyCode.A) && shouldaMove)
            {
                key = KeyCode.A;
                keyUI.GetComponent<Image>().sprite = SA;
                transform.Translate(-kidVelocity, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D) && shouldaMove)
            {
                key = KeyCode.D;
                keyUI.GetComponent<Image>().sprite = SD;
                transform.Translate(kidVelocity, 0f, 0f);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                key = KeyCode.Space;
                keyUI.GetComponent<Image>().sprite = SSpace;
                sr.sprite = kid_normal;
                shouldaMove = true;
            }
            if(key == KeyCode.None)
            {
                keyUI.GetComponent<Image>().enabled = false;
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
            shouldaMove = false;
        }
    }
}
