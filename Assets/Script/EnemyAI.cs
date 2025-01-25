using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public LayerMask whatGround, whatPlayer;

    //states (Idle, running or captured)
    public float sightRange;
    public bool playerInRange;
    public bool enemyCaptured;


    void Start()
    {
        target = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //checking if player is in range
        playerInRange = Physics.CheckSphere(transform.position, sightRange, whatPlayer);

        if (playerInRange)
        {
            runningAway();
        }
        if (!playerInRange)
        {
            idle();
        }
    }

    private void runningAway()
    {
        agent.destination = target.position - transform.position;
    }

    private void idle()
    {
        agent.velocity = Vector3.zero;
    }
}
