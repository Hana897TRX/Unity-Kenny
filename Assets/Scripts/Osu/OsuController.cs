using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsuController : MonoBehaviour
{
    public int totalObjects = 3;
    GameObject[] objects;
    public GameObject limInf, limSup;
    int count = 0;

    void Start()
    {
        objects = new GameObject[totalObjects];
        for(int i = 0; i < totalObjects; i++)
        {
            GameObject temp;
            int option = Random.Range(0, 3);
            switch(option)
            {
                case 0:
                    {
                        temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        temp.transform.SetParent(gameObject.transform, false);
                        break;
                    }
                case 1:
                    {
                        temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        temp.transform.SetParent(gameObject.transform, false);
                        break;
                    }
                default:
                    {
                        temp = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        temp.transform.SetParent(gameObject.transform, false);
                        break;
                    }
            }
            objects[i] = (temp);
            // Pendiente añadir texturas que indiquen el orden de los objetos
            // Requerimos assets
            temp.transform.position = new Vector3(Random.Range(limInf.transform.position.x, limSup.transform.position.x), Random.Range(limInf.transform.position.y, limSup.transform.position.y), Random.Range(limInf.transform.position.z, limSup.transform.position.z));
            temp.name = i.ToString();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    GameObject temp = hit.collider.gameObject;
                    if(int.Parse(temp.name) == count)
                    {
                        temp.GetComponent<MeshRenderer>().material.color = Color.blue; 
                        Destroy(temp, 1);
                        count++;
                    }
                    else
                    {
                        temp.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
    }
}
