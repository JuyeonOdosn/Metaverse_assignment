using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : BaseUI // 게임UI( 게임 실행) 전환을 위한 클래스입니다.
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
