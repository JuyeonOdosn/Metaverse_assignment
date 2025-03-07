using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour // 애니메이션
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }
}