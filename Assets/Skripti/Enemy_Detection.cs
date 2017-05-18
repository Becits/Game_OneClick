using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detection : MonoBehaviour {

    private Enemy_master enemyMaster;
    private Transform myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    private float detectRadius = 80;
    private RaycastHit hit;


    private void OnEnable()
    {
        SetInitialReferances();
    }

    private void OnDisable()
    {

    }

    void Update()
    {

    }

    void SetInitialReferances()
    {
        enemyMaster = GetComponent<Enemy_master>();
        myTransform = transform;

        if(head == null)
        {
            head = myTransform;
        }
        checkRate = Random.Range(0.8f, 1.2f);
    }

    void CarryOutDetection()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectRadius, playerLayer);

            if(colliders.Length > 0)
            {
                foreach (Collider potentialTargetCollider in colliders)
                {
                    /*if (potentialTargetCollider.CompareTag(player))
                    {
                        if (CanPotentialTargetBeSeen(potentialTargetCollider.transform)){
                            break;
                        }
                    }*/
                }
            }
            else
            {
                enemyMaster.CallEventEnemyLostTarger();
            }
        }
    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if(Physics.Linecast(head.position, potentialTarget.position, out hit, sightLayer))
        {
            if(hit.transform == potentialTarget)
            {
                enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                enemyMaster.CallEventEnemyLostTarger();
                return false;
            }
        }
        else
        {
            enemyMaster.CallEventEnemyLostTarger();
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }

}
