using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkEngine : MonoBehaviour
{
    [SerializeField]
    public GameObject[] chunksPrefab;
    List<GameObject> chunksMap;
    int chunk = 0;
    // Start is called before the first frame update
    void Start()
    {
        chunksMap = new List<GameObject>();
        StartCoroutine(MapEngine());
    }

    IEnumerator MapEngine()
    {
        int option = 0;

        while (true)
        {
            option = Random.Range(0, chunksPrefab.Length);
            GameObject temp = Instantiate(chunksPrefab[option]);
            temp.transform.position = new Vector3(0, 0, 10 * chunk);
            chunksMap.Add(temp);

            yield return new WaitForSeconds(2);
            chunk++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
