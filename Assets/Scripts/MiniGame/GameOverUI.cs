using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : BaseUI // ���ӿ��� UI ��ȯ�� ���� �ڵ� �Դϴ�.
{
    protected override UIState GetUIStates()
    {
        return UIState.GameOver;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }
}
