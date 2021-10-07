using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    Text txt;

    private void Start()
    {
        kid = GameObject.Find("kid");
        distanceTarget = maxDistance / instanceTimes;
        txt = txtObject.GetComponent<Text>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                realDistance += 0.5F;
                txt.text = realDistance.ToString();
                distance += 0.5F;
            }

            if (Input.GetKey(KeyCode.S))
            {
                realDistance -= 0.5F;
                txt.text = realDistance.ToString();
                distance -= 0.5F;
            }

            if (distance > distanceTarget - 5 && distance < distanceTarget + 5 && !instantiate)
            {
                GameObject temporal = Instantiate(saimon);
                temporal.transform.SetParent(kid.transform);
                temporal.transform.localScale = new Vector3(1, 1, 1);
                temporal.transform.localPosition = new Vector3(temporal.transform.position.x - 1.78F, temporal.transform.position.y - 4.0F, 5);
                instantiate = true;
            }
            else if (distance > distanceTarget)
            {
                distance -= distanceTarget;
                instantiate = false;
            }

            if(realDistance >= maxDistance)
            {
                Time.timeScale = 0;
            }
        }
    }
}
