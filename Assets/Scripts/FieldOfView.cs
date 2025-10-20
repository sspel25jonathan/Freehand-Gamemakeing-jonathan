using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Header("stats")]
    public float radius;
    [Range(0, 360)]
    public float angle;


    [Header("Transforms and objects")]
    public GameObject target;
    public GameObject Enemy;

    [Header("RayMasks")]

    public LayerMask targetMask;
    public LayerMask obstructions;


    private bool canSeePlayer;
    
    void Start()
    {
        StartCoroutine(FOVRoutine());
        StartCoroutine(LookingAtPlayer());
    }

    private IEnumerator FOVRoutine()
    {

        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;
            FieldOfViewChecks();
        }
    }

    private IEnumerator LookingAtPlayer()
    {
        while (true)
        {
            transform.LookAt(target.transform, Vector3.forward);
            yield return null;
        }
        
        

    }

    private void FieldOfViewChecks()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Vector3 directionToTarget = (this.transform.position - transform.position).normalized;

            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructions))
                {
                    canSeePlayer = true;
                    Debug.Log("sees PLayer");
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
