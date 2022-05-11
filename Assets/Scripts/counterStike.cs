using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterStike : MonoBehaviour
{
    int counter;
    public GameObject doggie, star1, star2, star3;
    public Sprite star, dog1, dog2, dog3;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            KeyCode key = KeyCode.None;
            doggie.GetComponent<Image>().enabled = true;
            star1.GetComponent<Image>().enabled = true;
            star2.GetComponent<Image>().enabled = true;
            star3.GetComponent<Image>().enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "target")
        {
            counter++;
            Debug.Log("counter changed");
        }

        if(counter == 1)
        {
            star1.GetComponent<Image>().sprite = star;
            doggie.GetComponent<Image>().sprite = dog1;
        }
        else if(counter == 2)
        {
            star2.GetComponent<Image>().sprite = star;
            doggie.GetComponent<Image>().sprite = dog2;
        }
        else if(counter == 3)
        {
            star3.GetComponent<Image>().sprite = star;
            doggie.GetComponent<Image>().sprite = dog3;
        }
    }
}
