using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Permissions;
using TMPro;
using UnityEngine.Networking;

public class RegName : Singleton<RegName>
{
    [SerializeField] private string authenticateEndPoint = "http://localhost:8000/account";
    [SerializeField] private TMP_InputField username;

    public void OnApply()
    {
        StartCoroutine(SaveName());
    }

    private IEnumerator SaveName()
    {
        string username = this.username.text;

        UnityWebRequest req = UnityWebRequest.Get($"{authenticateEndPoint}?rUsername={username}");
        var handler = req.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;
        }

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(req.downloadHandler.text);
        }
        else
        {
            Debug.Log("Unable to connect");
        }
    }
}