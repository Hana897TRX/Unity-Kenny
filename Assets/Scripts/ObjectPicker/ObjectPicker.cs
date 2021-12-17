using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public int totalObjects = 3;
    GameObject[] objects;
    public GameObject limInf, limSup, target, objectContainer;
    int count = 0;
    public GameObject[] pickObjects;

    void Start()
    {
        Debug.Log("Doing shit");
        objects = new GameObject[totalObjects];
        for (int i = 0; i < totalObjects; i++)
        {
            GameObject temp;
            int option = Random.Range(0, pickObjects.Length);

            temp = Instantiate(pickObjects[option]);
            //switch (option)
            //{
            //    case 0:
            //        {
            //            temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //            break;
            //        }
            //    case 1:
            //        {
            //            temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //            break;
            //        }
            //    default:
            //        {
            //            temp = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            //            break;
            //        }
            //}
            objects[i] = (temp);
            // Pendiente añadir texturas que indiquen el orden de los objetos
            // Requerimos assets
            temp.transform.SetParent(objectContainer.transform, false);
            temp.transform.position = new Vector3(Random.Range(limInf.transform.position.x, limSup.transform.position.x), Random.Range(limInf.transform.position.y, limSup.transform.position.y), Random.Range(limInf.transform.position.z, limSup.transform.position.z));
            temp.name = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject temp = hit.collider.gameObject;
                    if (int.Parse(temp.name) == count)
                    {
                        temp.GetComponent<MeshRenderer>().material.color = Color.green;
                        Destroy(temp, 1);
                        count++;
                    }
                    else
                    {
                        temp.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                }
            }
        }
    }
}
