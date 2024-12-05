using UnityEngine;
using TMPro;
using System;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextBinding : DataBinding
{
    public override Type BindingType => typeof(TextMeshProUGUI);

    protected override void Setup()
    {
        FindTarget<TextMeshProUGUI>();
    }
}
