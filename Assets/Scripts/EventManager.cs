using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    float distance = 0.0F;
    public GameObject txtObject;

    [SerializeField]
    public GameObject[] listObject;
    
    TextMeshProUGUI txt;

    private void Start()
    {
        txt = txtObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            distance += 0.5F * Time.deltaTime;
            txt.text = distance.ToString("0.0");
        }

        if (Input.GetKey(KeyCode.S))
        {
            distance -= 0.5F * Time.deltaTime;
            txt.text = distance.ToString("0.0");
        }
    }
}
