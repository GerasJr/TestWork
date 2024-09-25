using UnityEngine;
using DG.Tweening;

public class BigArrow : MonoBehaviour
{
    [SerializeField] private ClockTime _clockTime;

    private float _turnoverDegree = 360;
    private Vector3 _rotate;
    private float _duration = 0.15f;
    private float _clockFaceHours = 12;

    public void MoveArrow()
    {
        _rotate = transform.eulerAngles;
        _rotate.z = -(_turnoverDegree * _clockTime.GetHoursMotion()) / _clockFaceHours;
        transform.DORotate(_rotate, _duration);
    }
}
