using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


public class AI_WalkV2 : MonoBehaviour
{
    //public Player_MomentV3 fpsc;
    public Transform player;
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
        GameObject fpsc = GameObject.FindGameObjectWithTag("Player");
        player = fpsc.transform;
    }

    void Update()
    {
        //float distance = Vector3.Distance(fpsc.transform.position, transform.position);
        if (isAware)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Aware", true);
            agent.speed = chasesSpeed;
            renderer1.material.color = Color.red;
            if(!isDetecting)
            {
                loseTimer += Time.deltaTime;
                if (loseTimer >= loseTherehold)
                {
                    isAware = false;
                    loseTimer = 0;
                }
            }
        }
        else
        {
            Wander();
            animator.SetBool("Aware", false);
            renderer1.material.color = Color.blue;
        }
        SearchForPlayer();
    }

    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.position)) < fov / 2f)
        {
            if (Vector3.Distance(player.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, player.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                    else
                    {
                        isDetecting = false;
                    }
                }
                else
                {
                    isDetecting = false;
                }
            }
            else
            {
                isDetecting = false;
            }
        }
        else
        {
            isDetecting = false;
        }
    }

    public void OnAware()
    {
        isAware = true;
        isDetecting = true;
        loseTimer = 0;
    }

    public void Wander()
    {
        if (Vector3.Distance(transform.position, wanderPoint) < 2f)
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
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}