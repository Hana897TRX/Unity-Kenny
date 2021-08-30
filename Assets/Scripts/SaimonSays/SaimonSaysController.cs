using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaimonSaysController : MonoBehaviour
{
    public int totalObjects = 3;
    GameObject[] objects;
    public GameObject limInf, limSup;
    public GameObject objectContainer;
    int count = 0;

    void Start()
    {
        objects = new GameObject[totalObjects];
        for (int i = 0; i < totalObjects; i++)
        {
            GameObject temp;
            int option = Random.Range(0, 3);
            switch (option)
            {
                case 0:
                    {
                        GameObject objPrefab = Resources.Load("Apple") as GameObject;
                        //temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        temp = Instantiate(objPrefab) as GameObject;
                        break;
                    }
                case 1:
                    {
                        GameObject objPrefab = Resources.Load("Rock 5") as GameObject;
                        //temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        temp = Instantiate(objPrefab) as GameObject;
                        break;
                    }
                default:
                    {
                        GameObject objPrefab = Resources.Load("Bottle_05") as GameObject;
                        //temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        temp = Instantiate(objPrefab) as GameObject;
                        break;
                    }
            }
            temp.transform.SetParent(objectContainer.transform, false);
            objects[i] = (temp);
            temp.transform.position = new Vector3(Random.Range(limInf.transform.position.x, limSup.transform.position.x), Random.Range(limInf.transform.position.y, limSup.transform.position.y), Random.Range(limInf.transform.position.z, limSup.transform.position.z));
            temp.name = i.ToString();
        }

        //Change order objects
        
        lightSequence();
    }

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
                        //Destroy(temp, 1);
                        count++;
                    }
                    else
                    {
                        temp.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    }
                }
            }

            if(count == objects.Length)
            {
                mixIndexes();
                count = 0;
            }
        }
    }

    void lightSequence()
    {
        for (int i = 0; i < totalObjects; i++)
        {
            
            StartCoroutine(ChangeColor(i));
        }
    }

    IEnumerator ChangeColor(int i)
    {
        yield return new WaitForSeconds(i); 
        objects[i].GetComponent<MeshRenderer>().material.color = Color.blue;
        yield return new WaitForSeconds(i);
        objects[i].GetComponent<MeshRenderer>().material.color = Color.white;
    }

    void mixIndexes()
    {
        int[] newIndexes = new int[totalObjects];
        //genero un posible index
        //recorro el arreglo para ver si ya lo ingresaron
        //si ya lo ingresaron, repito
        //si no, inserto
        //Repetir hasta que el arreglo este lleno
        int counter = 0;
        
        while(newIndexes[totalObjects - 1] != 0)
        {
            int posIndex = Random.Range(0, totalObjects);
            bool repeat = false;

            for (int i = 0; i < totalObjects; i++)
            {
                if (newIndexes[i] == posIndex)
                {
                    repeat = true;
                    break;
                }
            }

            newIndexes[counter]  = posIndex;
            counter++;
        }


    }
}
