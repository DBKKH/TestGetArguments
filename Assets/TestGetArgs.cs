using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class TestGetArgs : MonoBehaviour
{
    private InputField argText;
    private string resultArgs = "None";

    private void Reset()
    {
        if(!TryGetComponent(out argText))
            gameObject.AddComponent<InputField>();
    }

    private void Awake()
    {
        argText = GetComponent<InputField>();
    }

    private void Start()
    {
        var args = Environment.GetCommandLineArgs();
        resultArgs = $"Args count = {args.Length.ToString()}{Environment.NewLine}";

        if (args.Length >= 100)
        {
            resultArgs += "Maximam = 100 args";
            return;
        }

        foreach (var arg in args)
        {
            resultArgs += $"{arg}, {Environment.NewLine}";
        }

        argText.text += resultArgs;
    }
}