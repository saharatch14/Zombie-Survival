using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


public class AI_Walk : MonoBehaviour
{
    public Player_MomentV3 fpsc;
    //public GameObject fpsc;
    public float waderSpeed = 1.25f;
    public float chasesSpeed = 3f;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float loseTherehold = 10f;
    public float wanderRadius = 3f;


    private Vector3 wanderPoint;
    private bool isAware = false;
    private bool isDetecting = false;
    private NavMeshAgent agent;
    private Renderer renderer1;
    private Animator animator;
    private int waypointIndex = 0;
    private float loseTimer = 0;

    // Update is called once per frame
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        renderer1 = GetComponent<Renderer>();
        wanderPoint = RandomWanderPoint();
    }

    void Update()
    {
        //float distance = Vector3.Distance(fpsc.transform.position, transform.position);
        if (isAware)
        {
            agent.SetDestination(fpsc.transform.position);
            animator.SetBool("Aware", true);
            renderer1.material.color = Color.red;
        }
        else
        {
            SearchForPlayer();
            Wander();
            animator.SetBool("Aware", false);
            renderer1.material.color = Color.blue;
        }
    }

    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                }
            }
        }
    }

    public void OnAware()
    {
        isAware = true;
    }

    public void Wander()
    {
        if(Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint,out navHit, wanderRadius,  -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}