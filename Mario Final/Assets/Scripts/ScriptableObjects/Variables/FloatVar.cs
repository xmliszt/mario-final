using UnityEngine;

[CreateAssetMenu(fileName = "FloatVar", menuName = "ScriptableObjects/FloatVar", order = 2)]
public class FloatVar : ScriptableObject
{
    private float _value = 0;
    public float Value {
        get {
            return _value;
        }
    }

    public void Set(float var)
    {
        _value = var;
    }

    public void Set(FloatVar var)
    {
        _value = var.Value;
    }

    public void Add(float var)
    {
        _value += var;
    }

    public void Add(FloatVar var)
    {
        _value += var.Value;
    }
}
