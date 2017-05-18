using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_master : MonoBehaviour {

    public Transform myTarget;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventEnemyWalking;
    public event GeneralEventHandler EventEnemyReachedNavTarget;
    public event GeneralEventHandler EventEnemyAttack;
    public event GeneralEventHandler EventEnemyLostTarger;

    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler EventEnemyDeductHealth;

    public delegate void NavTargerEventHandler(Transform targetTranform);
    public event NavTargerEventHandler EventEnemySetNavTarget;

    public void CallEventEnemyDeductHealth(int health)
    {
        if (EventEnemyDeductHealth != null)
        {
            EventEnemyDeductHealth(health);
        }
    }

    public void CallEventEnemySetNavTarget(Transform targTransform)
    {
        if (EventEnemySetNavTarget != null)
        {
            EventEnemySetNavTarget(targTransform);
        }
        myTarget = targTransform;
    }

    public void CallEventEnemyWalking()
    {
        if (EventEnemyWalking != null)
        {
            EventEnemyWalking();
        }
    }

    public void CallEventEnemyReachedNavTarget()
    {
        if (EventEnemyReachedNavTarget != null)
        {
            EventEnemyReachedNavTarget();
        }
    }

    public void CallEventEnemyAttack()
    {
        if (EventEnemyAttack != null)
        {
            EventEnemyAttack();
        }
    }

    public void CallEventEnemyLostTarger()
    {
        if (EventEnemyLostTarger != null)
        {
            EventEnemyLostTarger();
        }

        myTarget = null;
    }
}
