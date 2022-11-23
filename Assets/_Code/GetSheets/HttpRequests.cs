using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;

public class HttpRequests : MonoBehaviour
{
    enum MyEnum
    {
        ocupado,
        libre,
    }
    
    // private HashSet<int> validChars = new HashSet<int>(0,1);
    void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log(UpdateRequest("Asset: "+"GameRoom"));
        UpdateRequest("GameRoom");
        // Sanitizer.InverseSanitize()
    }

    public string UpdateRequest(string asset)
    {
        string path = "";
        path = "?resource="; 
        path += asset;
        return path;
        
        StartCoroutine(GetRequest("https://script.google.com/macros/s/AKfycbwdyXX1pAioy1_t_Y5oFUN9hfmyw0PCjgn8sjOE3ddbvsDp_FTJ-MraVKCfs3nq8cY8/exec " + path));
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