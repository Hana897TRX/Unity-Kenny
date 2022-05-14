using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterStike : MonoBehaviour
{
    int counter;
    public GameObject doggie, star1, star2, star3;
    public Sprite star, dog1, dog2, dog3;
    public Sprite dogCongelado, dogClothes;
    public Image finalResu;
    public GameObject gameEngine;
    GameEngine gameEngineScript;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        gameEngineScript = gameEngine.GetComponent<GameEngine>();
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

        if(gameEngineScript.actualTime > gameEngineScript.sesionTime)
        {
            if(counter == 0)
            {
                finalResu.sprite = dogCongelado;
            } else
            {
                finalResu.sprite = dogClothes;
            }
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
