using UnityEngine;

[DisallowMultipleComponent]
public abstract class DataBinding : MonoBehaviour
{
    [ReadOnly]
    public Object Target;
    public string DataID;
    public bool AutoRefreshDataID = true;

    private void Reset()
    {
        DataID = gameObject.name;
        Setup();
    }

    protected abstract void Setup();

    protected void FindTarget<T>() where T : Component
    {
        if (TryGetComponent<T>(out var component))
        {
            Target = component;
        }
        else
        {
            Debug.LogWarning($"Binding failed : No {typeof(T).Name} component found on {gameObject.name}");
        }
    }
}
