using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Events;

public class HTTPRequest : MonoBehaviour
{
    [SerializeField] private UnityEvent _requestIsSend;
    [SerializeField] private string _url;

    private int _hourValue;
    private int _minuteValue;
    private JsonFile _jsonFile = new JsonFile();
    private Coroutine _requestJob;

    private IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this._url);
        yield return request.SendWebRequest();
        _jsonFile = JsonUtility.FromJson<JsonFile>(request.downloadHandler.text);
        _hourValue = _jsonFile.hour;
        _minuteValue = _jsonFile.minute;
        _requestIsSend?.Invoke();
        StopCoroutine(_requestJob);
    }


    public void StartSendRequest()
    {
        _requestJob = StartCoroutine(SendRequest());
    }

    public int GetMinutes()
    {
        return _minuteValue;
    }

    public int GetHours()
    {
        return _hourValue;
    }
}

public class JsonFile
{
    public int hour;
    public int minute;
}
