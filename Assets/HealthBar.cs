using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    Player_Propoty player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Propoty>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.health;
    }
}
