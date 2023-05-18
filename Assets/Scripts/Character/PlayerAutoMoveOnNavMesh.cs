using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMoveOnNavMesh : MonoBehaviour
{
    public Transform center;
    public float maxRadius = 4f;
    public float minRadius = 0.5f;
    public float randomWeight = 1f;
    public float applyWeight = 40f;

    public NavMeshAgent agent;
    public float idleDuration = 3;

    // public CharacterAnimationController animationController;
    

    public void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        //AutoRandomRun();
    }

    public void DoStop()
    {
        StopAllCoroutines();
        agent.enabled = false;
        // animationController.PlayAnimation(0).SetSpeed(1);
    }

    public void DoRun()
    {
        agent.enabled = true;
        AutoRandomRun();
    }

    public void Floating()
    {
        // animationController.PlayAnimation(26).SetSpeed(0.2f);
    }

    #region Auto Run Functions
    public void AutoRandomRun()
    {
        StopAllCoroutines();
        StartCoroutine(IEDoRun2RandomPostion());
    }

    IEnumerator IEDoRun2RandomPostion()
    {
        Vector3 randomPosition = Vector3.zero;
        WaitForEndOfFrame waitEndOfFrame = new WaitForEndOfFrame();
        WaitForSeconds waitDoneIdle = new WaitForSeconds(idleDuration);
        while (true)
        {
            randomPosition = RandomNavmeshLocation();
            // if(agent.isStopped) agent.isStopped = false;
            agent.SetDestination(randomPosition);
            // animationController.PlayAnimation(1).SetSpeed(1);
            yield return new WaitUntil(() => DistanceIngoreY(randomPosition, transform.position) < 0.0001);
            
            // animationController.PlayAnimation(0);
            yield return waitDoneIdle;

        }
    }

    float DistanceIngoreY(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(Vector3.Distance(a, b) - Mathf.Abs(a.y - b.y));
    }

    Vector3 RandomNavmeshLocation()
    {
        float radius = Random.Range(minRadius, maxRadius);
        bool applyFocusCenter = Random.Range(0, 100) < applyWeight;
        Vector3 randomDirection = Random.insideUnitSphere;
        if (applyFocusCenter)
            randomDirection = (randomDirection * randomWeight - (transform.position - center.position)).normalized * radius;
        else randomDirection = randomDirection * radius;
        randomDirection += transform.position;
        // NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        // if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        // {
        //     finalPosition = hit.position;
        // }
        
        return finalPosition;
    }

    
    #endregion
}
