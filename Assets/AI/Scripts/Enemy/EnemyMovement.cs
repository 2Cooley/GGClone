using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public GameObject target;
    private bool Activated = false;
    public NavMeshAgent agent;

    void Update()
    {
        if (Activated) agent.SetDestination(target.transform.position);
    }

    public void ActivateMovement()
    {
        Activated = true;
    }

    public void StopMovement()
    {
        agent.Stop();
    }
}
