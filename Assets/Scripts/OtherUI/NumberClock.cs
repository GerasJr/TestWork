using UnityEngine;
using TMPro;

public class NumberClock : MonoBehaviour
{
    [SerializeField] private ClockTime _clockTime;
    [SerializeField] private TMP_Text _text;

    private int _dozen = 10;
    private string _visualHours;
    private string _visualMinutes;
    private string _visualSeconds;

    private void Update()
    {
        _visualHours = _clockTime.GetHoursMotion() < _dozen ? $"0{(int)_clockTime.GetHoursMotion()}" : $"{(int)_clockTime.GetHoursMotion()}";
        _visualMinutes = _clockTime.GetMinutesMotion() < _dozen ? $"0{(int)_clockTime.GetMinutesMotion()}" : $"{(int)_clockTime.GetMinutesMotion()}";
        _visualSeconds = _clockTime.GetSecondsMotion() < _dozen ? $"0{(int)_clockTime.GetSecondsMotion()}" : $"{(int)_clockTime.GetSecondsMotion()}";
        _text.text = $"{_visualHours}:{_visualMinutes}:{_visualSeconds}";
    }
}
