using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersEngine : MonoBehaviour
{
    public GameObject lettersGame;
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
        while(counter < spawnCount) {
            GameObject temp = Instantiate(
                lettersGame, 
                new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), 
                Quaternion.identity
            );
            yield return new WaitForSeconds(spawnTime);
            temp.transform.parent = gameObject.transform;
            counter++;
        }
    }
}
