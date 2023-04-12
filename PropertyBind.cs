using System;
using UnityEngine;

[Serializable]
public class PropertyBind<T>
{
    event Action<T> OnValueChanged;

    public PropertyBind(T value)
    {
        _value = value;
    }

    public PropertyBind()
    {
        _value = default(T);
    }

    [SerializeField] T _value = default(T);
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChanged?.Invoke(value);
        }
    }

    public static implicit operator T(PropertyBind<T> property)
    {
        return property.Value;
    }

    public static implicit operator PropertyBind<T>(T value)
    {
        return new PropertyBind<T>(value);
    }

    public void AddListener(Action<T> action)
    {
        OnValueChanged += action;
    }

    public void RemoveListener(Action<T> action)
    {
        OnValueChanged -= action;
    }

    public void Reset()
    {
        _value = default(T);
    }

    public void Reset(T value)
    {
        _value = value;
    }
}