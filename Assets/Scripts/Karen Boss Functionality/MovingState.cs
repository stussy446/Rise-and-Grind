using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : IKarenState
{
    public void Idling(IKarenContext context)
    {
    }


    public void Moving(IKarenContext context)
    {
    }


    public void Attacking(IKarenContext context)
    {
        Debug.Log("transitioning from Moving State to Attacking state");

        context.SetState(new AttackingState());
    }


    public void DamageTaking(IKarenContext context)
    {
        Debug.Log("transitioning from Moving State to DamageTaking state");

        context.SetState(new DamageTakingState());
    }


    public void Dying(IKarenContext context)
    {
        Debug.Log("transitioning from Moving State to Dying state");

        context.SetState(new DyingState());
    }
}
