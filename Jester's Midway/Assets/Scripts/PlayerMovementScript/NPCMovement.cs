using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float wanderTimer = 4f;

    private NavMeshAgent agent;
    private float timer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavPoint(transform.position, wanderRadius);
            agent.SetDestination(newPos);
            timer = 0f;
        }
    }

    Vector3 RandomNavPoint(Vector3 origin, float dist)
    {
        Vector3 randomDir = Random.insideUnitSphere * dist;
        randomDir += origin;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDir, out hit, dist, NavMesh.AllAreas);
        return hit.position;
    }
}