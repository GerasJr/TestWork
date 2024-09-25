using UnityEngine;
using UnityEngine.UI;

public class InputFieldReader : MonoBehaviour
{
    [SerializeField] Text _inputField;
    [SerializeField] int _unit = 0; //Where 0 - hour, 1 - minute, 2 - second

    public string GetInputValue()
    {
        return _inputField.text;
    }

    public int GetUnit()
    {
        return _unit;
    }
}
