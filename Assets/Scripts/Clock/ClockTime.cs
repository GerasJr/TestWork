using UnityEngine;
using UnityEngine.Events;

public class ClockTime : MonoBehaviour
{
    [SerializeField] private UnityEvent _minutePassed;
    [SerializeField] private HTTPRequest _httpRequest;

    private bool _isCostomize = false;
    private float _seconds = 0;
    private float _minutes = 0;
    private float _hours = 0;
    public float SecondsInMinute { get; private set; } = 60;
    public float MinutsInHour { get; private set; } = 60;
    public float HoursInDay { get; private set; } = 24;

    private void Start()
    {
        _httpRequest.StartSendRequest();
    }

    void Update()
    {
        _seconds += Time.deltaTime;

        if (_seconds >= SecondsInMinute)
        {
            ++_minutes;
            UpdateMinutes();
            _seconds = 0;
            _minutePassed?.Invoke();
        }
    }

    private void UpdateMinutes()
    {
        if (_minutes >= MinutsInHour)
        {
            ++_hours;
            UpdateHours();
            _minutes = 0;
        }
    }

    private void UpdateHours()
    {
        if (_isCostomize == false)
        {
            SetWorldTime();
        }

        if (_hours >= HoursInDay)
        {
            _hours = 0;
        }
    }

    public void CostomizeTimeValue()
    {
        float duration = 200;
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _minutes = _minutes + mousepos.y / duration;
        UpdateMinutes();

        if (_minutes < 0)
        {
            _hours--;
            _minutes = MinutsInHour - 1;

            if (_hours < 0)
            {
                _hours = HoursInDay - 1;
            }
        }
    }

    public void SetWorldTime()
    {
        _httpRequest.StartSendRequest();
        _minutes = _httpRequest.GetMinutes();
        _hours = _httpRequest.GetHours();
    }

    public void CustomizeTime(bool isCostomize)
    {
        _isCostomize = isCostomize;
    }

    public float GetHoursMotion()
    {
        return _hours + _minutes * (1 / MinutsInHour);
    }

    public float GetMinutesMotion()
    {
        return _minutes + _seconds * (1 / SecondsInMinute);
    }

    public float GetSecondsMotion()
    {
        return _seconds;
    }

    public void UpdateTimeValue(InputFieldReader inputFieldReader)
    {
        string stringValue = inputFieldReader.GetInputValue();
        int.TryParse(stringValue, out int value);

        if(value >= 0)
        {
            switch (inputFieldReader.GetUnit())
            {
                case 0:
                    if (value < HoursInDay)
                    {
                        _hours = value;
                    }
                    break;
                case 1:
                    if(value < MinutsInHour)
                    {
                        _minutes = value;
                    }
                    break;
                case 2:
                    if (value < SecondsInMinute)
                    {
                        _seconds = value;
                    }
                    break;
            }
        }
    }
}
