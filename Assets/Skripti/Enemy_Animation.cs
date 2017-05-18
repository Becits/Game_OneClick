using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour {

    private Enemy_master enemyMaster;
    private Animator myAnimator;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyWalking += SetAnimationToWalk;
        enemyMaster.EventEnemyAttack += SetAnimationToAttack;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
        enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_master>();

        if(GetComponent<Animator>() != null)
        {
            myAnimator = GetComponent<Animator>();
        }
    }
    void SetAnimationToWalk()
    {
        if(myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", false);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetTrigger("Attack");
            }
        }
    }

    void DisableAnimator()
    {
        if(myAnimator != null)
        {
            myAnimator.enabled = false;
        }
    }

}
