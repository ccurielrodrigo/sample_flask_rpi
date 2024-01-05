using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CallServer : MonoBehaviour
{
    // The URL you want to request
    private string serverUrl = "http://192.168.100.46:5000/";
    private string serverUrlForPost = "http://192.168.100.46:5000/post";
    public string postData = "This is the data to send in the POST request";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeRequests());

    }

    // Send a couple of requests (GET and POST)
    IEnumerator MakeRequests()
    {
        // Send a GET request
        yield return StartCoroutine(MakeGetRequest());

        // Send a POST request
        yield return StartCoroutine(MakePostRequest());
    }

    // GET Request
    IEnumerator MakeGetRequest()
    {
        // Create a UnityWebRequest object to make the GET request
        using (UnityWebRequest webRequest = UnityWebRequest.Get(serverUrl))
        {
            // Send the request and wait for the response
            yield return webRequest.SendWebRequest();

            // Check for any errors during the request
            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // Request was successful, you can access the response data here
                string responseData = webRequest.downloadHandler.text;
                Debug.Log("Response: " + responseData);
            }
        }
    }

    // POST Request

    IEnumerator MakePostRequest()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("message", postData));

        using (UnityWebRequest webRequest = UnityWebRequest.Post(serverUrlForPost, formData))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("POST Error: " + webRequest.error);
            }
            else
            {
                string responseData = webRequest.downloadHandler.text;
                Debug.Log("POST Response: " + responseData);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
