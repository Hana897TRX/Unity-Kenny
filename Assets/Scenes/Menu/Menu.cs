using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        //GameObject.Find("Canvas").transform.Find("Loading").gameObject.SetActive(true);
        //fade.color = new Color(0, 0, 0, 0);
        //fade.gameObject.SetActive(true);
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        //Color targetColor = new Color(0, 0, 0, 1);
        //for (float t=0.0f; t<1.0f; ) {
        //fade.color = Color.Lerp(fade.color, targetColor, t);
        //t = Mathf.Clamp(t + Time.deltaTime, 0.0f, 1.0f);
        //yield return null;
        //}
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
