using UnityEngine;

[CreateAssetMenu(fileName = "BoolVar", menuName = "ScriptableObjects/BoolVar", order = 2)]
public class BoolVar : ScriptableObject
{
    private bool _value = false;
    public bool Value {
        get {
            return _value;
        }
    }

    public void Set(bool var)
    {
        _value = var;
    }

    public void Set(BoolVar var)
    {
        _value = var.Value;
    }

    public void Flip()
    {
        _value = !_value;
    }
}
