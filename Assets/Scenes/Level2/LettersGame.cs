using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersGame : MonoBehaviour
{
    public GameObject initPos, finalPos;
    public List<GameObject> objectList;
    List<GameObject> objectsReferences = new List<GameObject>();

    public float velocity = 0.05F;

    public float separationX = 0F;
    public float spawnTime = 0.5F;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnObjects());
        StartCoroutine(Rolling());
    }

    IEnumerator SpawnObjects() {
        objectsReferences.Add(
            Instantiate(
                objectList[0],
                new Vector3(
                    initPos.transform.position.x,
                    initPos.transform.position.y,
                    initPos.transform.position.z
                ),
                Quaternion.identity)
            );
        objectsReferences[0].transform.parent = transform;

        yield return new WaitForSeconds(spawnTime);

        for(int i = 1; i < objectList.Count; i++) {
            objectsReferences.Add(
                Instantiate(
                    objectList[i],
                    new Vector3(
                        separationX * 100,
                        initPos.transform.position.y,
                        objectList[i].transform.position.z
                    ),
                    Quaternion.identity)
            );
            objectsReferences[i].transform.parent = transform;

            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator Rolling() {
        while(true) {
            for(int i = 0; i < objectsReferences.Count; i++) {
                objectsReferences[i].transform.position =
                    new Vector3(
                        objectsReferences[i].transform.position.x + velocity,
                        objectsReferences[i].transform.position.y,
                        objectsReferences[i].transform.position.z
                    );

                yield return null;

                if(objectsReferences[i].transform.position.x > finalPos.transform.position.x) {
                    objectsReferences[i].transform.position = initPos.transform.position;
                }
            }
        }
    }
}
