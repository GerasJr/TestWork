using UnityEngine;

public class ClockMechanism : MonoBehaviour
{
    [SerializeField] private SecondArrow _secondArrow;
    [SerializeField] private SmallArrow _smallArrow;
    [SerializeField] private BigArrow _bigArrow;

    private ClockTime _clockTime;
    private bool _isCostomizeTime = false;

    private void Start()
    {
        _clockTime = GetComponent<ClockTime>();
    }

    private void Update()
    {
        if (_isCostomizeTime)
        {
            _clockTime.CostomizeTimeValue();
            UpdateArrows();
        }
    }

    public void UpdateArrows()
    {
        _smallArrow.MoveArrow();
        _bigArrow.MoveArrow();
    }

    private void OnMouseDown()
    {
        _isCostomizeTime = true;
        _clockTime.CustomizeTime(_isCostomizeTime);
    }

    private void OnMouseUp()
    {
        _isCostomizeTime = false;
        _clockTime.CustomizeTime(_isCostomizeTime);
    }
}
