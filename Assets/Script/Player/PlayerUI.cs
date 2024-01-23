using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);
    private const string authenticateEndPoint = "http://localhost:8000/accounts";
    [SerializeField] private TextMeshProUGUI playerName;
    
    private void Update()
    {
        DisplayTitle();
    }

    private void DisplayTitle()
    {
        transform.LookAt(trans);
        transform.Rotate(offset);
    }

    //private IEnumerator GetName()
    //{
    //    string username = this.playerName.text;

    //    UnityWebRequest req = UnityWebRequest.Get(authenticateEndPoint);
    //    var handler = req.SendWebRequest();

    //    float startTime = 0.0f;
    //    while (!handler.isDone)
    //    {
    //        startTime += Time.deltaTime;

    //        if (startTime > 10.0f)
    //        {
    //            break;
    //        }

    //        yield return null;
    //    }

    //    if (req.result == UnityWebRequest.Result.Success)
    //    {
    //        Debug.Log(req.downloadHandler.text);
    //    }
    //    else
    //    {
    //        Debug.Log("Unable to connect");
    //    }
    //}
}
