using System.Collections.Generic;
using UnityEngine;

public class DataBinder : MonoBehaviour
{
    private readonly Dictionary<string, Object> _bindings = new();

    private void Awake()
    {
        FindDataBindings();
    }

    public T Get<T>(string id) where T : Object
    {
        if (_bindings.TryGetValue(id, out var data))
        {
            return data as T;
        }

        return null;
    }

    public bool Contains(string id)
    {
        return _bindings.ContainsKey(id);
    }

    private void FindDataBindings()
    {
        var dataBindings = gameObject.GetComponentsInChildren<DataBinding>(true);

        foreach (var binding in dataBindings)
        {
            if (IsNullBinding(binding))
            {
                LogWarning($"Binding failed : ID or Target is null", binding);
                continue;
            }

            if (_bindings.ContainsKey(binding.DataID))
            {
                LogWarning($"Binding failed : Duplicate ID '{binding.DataID}'", binding);
                continue;
            }

            _bindings.Add(binding.DataID, binding.Target);
        }
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
