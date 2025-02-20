using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class StartUI : BaseUI //StartUI Å¬·¡½º
{
    protected override UIState GetUIStates()
    {
        return UIState.Start;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }
}
