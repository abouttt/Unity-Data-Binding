using System;
using System.Collections.Generic;
using UnityEngine;

public class DataBinder : MonoBehaviour
{
    private readonly Dictionary<Type, Dictionary<string, Component>> _bindings = new();

    private void Awake()
    {
        FindDataBindings();
    }

    public T Get<T>(string id) where T : Component
    {
        if (_bindings.TryGetValue(typeof(T), out var type))
        {
            if (type.TryGetValue(id, out var component))
            {
                return component as T;
            }
        }

        return null;
    }

    private void FindDataBindings()
    {
        foreach (var binding in gameObject.GetComponentsInChildren<DataBinding>(true))
        {
            if (IsNullBinding(binding))
            {
                LogWarning($"Binding failed : ID or Target is null", binding);
                continue;
            }

            AddBinding(binding);
        }
    }

    private void AddBinding(DataBinding binding)
    {
        if (!_bindings.TryGetValue(binding.BindingType, out var typeBindings))
        {
            typeBindings = new Dictionary<string, Component>();
            _bindings[binding.BindingType] = typeBindings;
        }

        if (typeBindings.ContainsKey(binding.DataID))
        {
            LogWarning($"Binding failed : Duplicate ID", binding);
            return;
        }

        typeBindings.Add(binding.DataID, binding.Target);
    }

    private bool IsNullBinding(DataBinding binding)
    {
        return string.IsNullOrEmpty(binding.DataID) || binding.Target == null;
    }

    private void LogWarning(string message, DataBinding binding)
    {
        Debug.LogWarning($"[DataBinder] {gameObject.name} - {message} (ID : {binding.DataID}, Target : {binding.Target})");
    }
}
