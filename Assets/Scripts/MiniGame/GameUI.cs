using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : BaseUI // ����UI( ���� ����) ��ȯ�� ���� Ŭ�����Դϴ�.
{
    protected override UIState GetUIStates()
    {
        return UIState.Game;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }
}
