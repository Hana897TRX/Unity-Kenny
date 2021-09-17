using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    float distance = 0.0F;
    public GameObject txtObject;

    [SerializeField]
    public GameObject saimon;
    GameObject kid;
    public int instanceTimes;
    public float maxDistance = 500F;
    float distanceTarget = 0.0F;
    float realDistance = 0.0F;
    bool instantiate = false;
    
    TextMeshProUGUI txt;

    private void Start()
    {
        kid = GameObject.Find("kid");
        distanceTarget = maxDistance / instanceTimes;
        txt = txtObject.GetComponent<TextMeshProUGUI>();
        //StartCoroutine(EventsLoop());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { 
            realDistance += 0.5F * Time.deltaTime; 
            txt.text = realDistance.ToString("0.0");
            distance += 0.5F;
        }

        if (Input.GetKey(KeyCode.S))
        {
            realDistance -= 0.5F * Time.deltaTime;
            txt.text = realDistance.ToString("0.0");
            distance += 0.5F;
        }

        if (distance > distanceTarget - 5 && distance < distanceTarget + 5 && !instantiate)
        {
            GameObject temporal = Instantiate(saimon);
            temporal.transform.SetParent(kid.transform);
            temporal.transform.localScale = new Vector3(1, 1, 1);
            temporal.transform.localPosition = new Vector3(temporal.transform.position.x - 1.78F, temporal.transform.position.y -1.0F, 5);
            instantiate = true;
        }
        else if (distance > distanceTarget)
        {
            distance -= distanceTarget;
        }
    }

    /*
    IEnumerator EventsLoop()
    {
        while(realDistance < maxDistance)
        {
            if (distance > distanceTarget - 5 && distance < distanceTarget + 5 && !instantiate)
            {
                GameObject temporal = Instantiate(saimon);
                temporal.transform.SetParent(kid.transform);
                instantiate = true;
            }
            else if (distance > distanceTarget)
            {
                distance -= distanceTarget;
            }
            yield return null;
        }
    }
    */
}
