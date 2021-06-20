using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecttocollect2 : MonoBehaviour
{
    public float Heal = 25f;
    //public static int objects = 0;
    // Start is called before the first frame update
    void Awake()
    {
        //objects++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 90 * Time.deltaTime);
        //objects++;
    }
    void OnTriggerEnter(Collider plar)
    {
        if ((plar.gameObject.tag == "Player" || plar.name == "Player") && plar.GetComponent<Player_Propoty>().health < 100)
        {
            plar.GetComponent<Player_Propoty>().Heling(Heal);
            Destroy(gameObject);
        }
        //gameObject.SetActive(false);
    }

}
