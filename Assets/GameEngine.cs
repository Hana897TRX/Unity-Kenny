using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject gameOver;
    public float sesionTime;
    float actualTime;
    void Start()
    {
        actualTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;

        if(actualTime >= sesionTime)
        {
            gameOver.SetActive(true);
        }
    }
}
