using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : BaseUI // 게임오버 UI 전환을 위한 코드 입니다.
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
