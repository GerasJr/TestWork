using UnityEngine;
using DG.Tweening;

public class SmallArrow : MonoBehaviour
{
    [SerializeField] private ClockTime _clockTime;

    private int _turnoverDegree = 360;
    private Vector3 _rotate;
    private float _duration = 0.15f;
    public void MoveArrow()
    {
        _rotate = transform.eulerAngles;
        _rotate.z = -(_turnoverDegree * _clockTime.GetMinutesMotion()) / _clockTime.MinutsInHour;
        transform.DORotate(_rotate, _duration);
    }
}
