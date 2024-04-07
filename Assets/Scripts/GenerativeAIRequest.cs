
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GenerativeAIRequest : MonoBehaviour
{
    private const string apiUrl = "https://generative-ai-api.com/generate";

    public IEnumerator CallGenerativeAI(string inputData)
    {
        string jsonData = "{\"inputData\":\"" + inputData + "\"}";

        using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, jsonData))
        {
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseData = www.downloadHandler.text;
                Debug.Log("Generated content: " + responseData);
            }
            else
            {
                Debug.LogError("Error calling Generative AI: " + www.error);
            }
        }
    }
}
