using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LettersEngine : MonoBehaviour
{
    public float delay;
    public List<GameObject> lettersGame;
    public float spawnTime = 200F;
    public int spawnCount = 3;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generator());
    }

    IEnumerator Generator() {
        int counter = 0;
        int iterator = 0;
        yield return new WaitForSeconds(delay);
        while(counter < spawnCount) {
            GameObject temp = Instantiate(
                lettersGame[iterator],
                new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), 
                Quaternion.identity
            );
            //temp.transform.parent = gameObject.transform;
            counter++;
            iterator++;
            Debug.Log("iterator");
            Debug.Log(iterator);
            /*if(iterator >= lettersGame.Count); {
                iterator = 0;
            }*/
            Debug.Log("Hello");
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
