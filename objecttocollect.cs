using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objecttocollect : MonoBehaviour
{
    //public static int objects = 0;
    // Start is called before the first frame update
    void Awake ()
    {
        //objects++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
        //objects++;
    }
    void OnTriggerEnter(Collider plar)
    {
        if (plar.gameObject.tag == "Player" || plar.name == "Player")
        {

            plar.GetComponent<PlayerCollect>().points = plar.GetComponent<PlayerCollect>().points + 30;
            Destroy(gameObject);
        }
        //gameObject.SetActive(false);
    }
}
