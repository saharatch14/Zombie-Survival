using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class Player_Propoty : MonoBehaviour
{
    public float soundIntensity = 5f;
    public float walkEnemyPrecepttionRadius = 1f;
    public float sprintEnemyPrecepttionRadius = 1.5f;
    public LayerMask zombieLayer;
    public float health;

    public Player_MomentV3 fpsc;
    private SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        fpsc = GetComponent<Player_MomentV3>();
        sphereCollider = GetComponent<SphereCollider>();
        health = GlobalControl.Instance.HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0f)
        {
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
            if (fpsc.GetPlayerSteal() == 0 || fpsc.m_walk == true)
            {
                sphereCollider.radius = walkEnemyPrecepttionRadius;
            }
            else
            {
                sphereCollider.radius = sprintEnemyPrecepttionRadius;
            }
        }
        else
        {
            FindObjectOfType<GameManager>().EndGame();
        }


    }

    public void Fire()
    {
        Collider[] zombies = Physics.OverlapSphere(transform.position, soundIntensity, zombieLayer);
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i].GetComponent<AI_WalkV2>().OnAware();
        }
    }

    public void OnTriggerEvent(Collider other)
    {
        if(other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<AI_WalkV2>().OnAware();
        }
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("UnderAttck");
        health -= amount;
    }
    public void Heling(float amount)
    {
        Debug.Log("Recover");
        health += amount;
    }
    private void OnGUI()
    {
        //GUI.Label(new Rect(500, 10, 100, 20),health.ToString());

    }
}
