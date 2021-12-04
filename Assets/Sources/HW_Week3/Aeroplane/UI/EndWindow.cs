using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWindow : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
