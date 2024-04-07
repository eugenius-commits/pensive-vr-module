using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MemoryManager : MonoBehaviour
{
    private const string baseUrl = "https://memory-api-url.com/api/memories";

    public IEnumerator GetAllMemories()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("All Memories: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error retrieving all memories: " + www.error);
            }
        }
    }

    public IEnumerator GetMemoryByID(string id)
    {
        string url = baseUrl + "/" + id;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Memory ID " + id + ": " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error retrieving memory ID " + id + ": " + www.error);
            }
        }
    }

    public IEnumerator CreateMemory(string newMemoryData)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, newMemoryData))
        {
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

    public IEnumerator UpdateMemory(string id, string updatedMemoryData)
    {
        string url = baseUrl + "/" + id;

        using (UnityWebRequest www = UnityWebRequest.Put(url, updatedMemoryData))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Memory ID " + id + " updated successfully: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error updating memory ID " + id + ": " + www.error);
            }
        }
    }

    public IEnumerator DeleteMemory(string id)
    {
        string url = baseUrl + "/" + id;

        using (UnityWebRequest www = UnityWebRequest.Delete(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Memory ID " + id + " deleted successfully.");
            }
            else
            {
                Debug.LogError("Error deleting memory ID " + id + ": " + www.error);
            }
        }
    }
}
