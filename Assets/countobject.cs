using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countobject : MonoBehaviour
{
    public string nextLevel;
    public GameObject objToDestroy;
    public GameObject objUI;
    // Start is called before the first frame update
    void Start()
    {
        objUI = GameObject.Find("ObjectNum");
    }

    // Update is called once per frame
    void Update()
    {
        //objUI.GetComponent<Text>().text = ObjectsToCollect.objects.Tostring();
        //if(objectstocollect.Object == 0)
        {
            Destroy(objToDestroy);
       //     objUI.GetComponent<Text>().text = "All object collected";
        }
    }
}
