using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class StartUI : BaseUI //StartUI Ŭ����
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
