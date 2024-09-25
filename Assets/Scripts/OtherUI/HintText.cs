using UnityEngine;
using DG.Tweening;
using TMPro;

public class HintText : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private TMP_Text text;

    private Vector3 _jumpEndValue;
    private float _powerJump = 0.4f;
    private float _durationJump = 1f;
    private float _durationColor = 15f;

    private void Start()
    {
        _jumpEndValue = new Vector3(transform.position.x, 0f);
        text.transform.DOJump(_jumpEndValue, _powerJump, 1, _durationJump);
        text.DOColor(_color, _durationColor);
    }
}
