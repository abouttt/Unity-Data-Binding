using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestCanvas : MonoBehaviour
{
    private DataBinder _binder;

    private void Awake()
    {
        _binder = new(gameObject);
    }

    private void Start()
    {
        Debug.Log(_binder.Get<TestComponent>("TestComponent").name);
        Debug.Log(_binder.Get<GameObject>("GameObject").name);
        Debug.Log(_binder.Get<Image>("ImageOne").name);
        Debug.Log(_binder.Get<Image>("ImageTwo").name);
        Debug.Log(_binder.Get<TextMeshProUGUI>("Text").name);
    }
}
