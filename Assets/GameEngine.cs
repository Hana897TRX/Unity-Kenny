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
        StartCoroutine(GameControll());
    }

    IEnumerator GameControll()
    {
        while (true)
        {
            actualTime += Time.deltaTime;

            if (actualTime >= sesionTime)
            {
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
            yield return null;
        }
    }
}
