using UnityEngine;

public class SecondArrow : MonoBehaviour
{
    [SerializeField] private ClockTime _clockTime;

    private int _turnoverDegree = 360;
    private Vector3 rotate;

    void Update()
    {
        rotate = transform.eulerAngles;
        rotate.z = (_turnoverDegree * -_clockTime.GetSecondsMotion()) / _clockTime.SecondsInMinute;
        transform.rotation = Quaternion.Euler(rotate);
    }
}