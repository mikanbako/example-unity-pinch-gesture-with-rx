using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed class ScaleLabel : MonoBehaviour {
    private const string Label = "Scale : ";

    private Text _scaleText;

    public void OnScale(Scaling scaling)
    {
        SetScaleText(scaling.Scale);
    }

    private void Start()
    {
        _scaleText = GetComponent<Text>();

        SetScaleText(1);
    }

    private void SetScaleText(float scale)
    {
        _scaleText.text = string.Format(
            Label + "{0:F2}", scale);
    }
}
