using UnityEngine;
using UnityEngine.UI;

public class TestCanvas : MonoBehaviour
{
    private DataBinder _binder;

    private void Awake()
    {
        _binder = GetComponent<DataBinder>();
    }

    private void Start()
    {
        var image = _binder.Get<Image>("FooImage");
        Debug.Log(image.name);
    }
}
