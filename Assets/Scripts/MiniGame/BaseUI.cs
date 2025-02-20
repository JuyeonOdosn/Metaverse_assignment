using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour //GameUI, StartUI, GameOverUI를 위한 추상클래스입니다.
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uiManager;
    }
    
    protected abstract UIState GetUIStates();

    public void SetActive(UIState uIStates)
    {
        gameObject.SetActive(GetUIStates() == uIStates);
    }
}
