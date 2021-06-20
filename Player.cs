using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Propoty player;
    public shoot gun;
    public PlayerCollect Collect;
    public float health;
    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player_Propoty>();
        gun = GetComponent<shoot>();
        Collect = GetComponent<PlayerCollect>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        Player_data data = SaveSystem.LoadPlayer();

        health = 100;
        ammo = Collect.points;

    }
}
