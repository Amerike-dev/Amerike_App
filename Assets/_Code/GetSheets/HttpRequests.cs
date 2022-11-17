using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;

public class HttpRequests : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest("https://script.google.com/macros/s/AKfycbxQEfUWoUu0gNcGUyJVkmCPRaqxWz30doEldNUCX6FMgkRqNRmX-XUuBIu2WE2VN3MN/exec"));
        //randomId = Random.Range(1,905);
        
        StartCoroutine(GetRequest("https://script.google.com/macros/s/AKfycbzW4RadKxuksUmYmiyIZhryY-etqRNBTqPzIhuIcoGuXg82gz7WCx4WK1021GrWRHuv/exec?resource=LabVerde"));
        
        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    void Update()
    {

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log("Sending Request ");
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(pages[page]);
                    // Debug.Log(webRequest.downloadHandler.text);
                    Debug.Log(pages[page]+ ":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode root = JSONNode.Parse(webRequest.downloadHandler.text);
                    
                    Debug.Log("Request CallBack");
                    break;
            }
        }
    }

    void SerializeSchedule(JSONNode root)
    {
            
    }
}