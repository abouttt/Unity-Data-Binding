using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBinding : DataBinding
{
    protected override void Setup()
    {
        FindTarget<Image>();
    }
}
