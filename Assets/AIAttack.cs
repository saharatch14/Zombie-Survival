using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public float maxDistance;
    public float coolDownTimer;
    private Transform player;
    public Transform target;
    public Player_Propoty play;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Player_Propoty>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        player = transform;
        maxDistance = 2;
        coolDownTimer = 0;

        play = (Player_Propoty)go.GetComponent(typeof(Player_Propoty));
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, player.position);
        if (distance < maxDistance)
        {
            Attack();
        }
        if (coolDownTimer > 0)
        {
            coolDownTimer = coolDownTimer * Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        void Attack()
        {
            Vector3 dir = Vector3.Normalize(target.position - player.position);
            float directioh = Vector3.Dot(dir, transform.forward);
            //Debug.Log(directioh);
            if (directioh > 0)
            {
                if (coolDownTimer == 0)
                {
                    play.TakeDamage(damage);
                    coolDownTimer = 3;
                }
            }
        }
    }
}
