using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AuthMemoryModule : MonoBehaviour
{
    private const string baseUrl = "https://auth-api-url.com/api/auth-memory";

    public IEnumerator AuthenticateAndCreateMemory(string username, string password, string memoryData)
    {
        string jsonData = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"memoryData\":\"" + memoryData + "\"}";

        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, jsonData))
        {
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Memory created successfully: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error creating memory: " + www.error);
            }
        }
    }
}
