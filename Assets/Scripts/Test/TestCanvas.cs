using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestCanvas : MonoBehaviour
{
    private DataBinder _binder;

    private void Awake()
    {
        _binder = GetComponent<DataBinder>();
    }

    private void Start()
    {
        Debug.Log(_binder.GetObject("GameObject").name);
    }
}
