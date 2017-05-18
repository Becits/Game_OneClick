using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    //public GameObject panelGameOver;


    public int lives = 5;
    public Transform respawn;
    public Transform fallout_lava;
    public Transform fallout_water;
    public Transform fallout_zombie;


    private void OnTriggerEnter(Collider Player)
    {
        if (Player.transform == fallout_lava || fallout_water || fallout_zombie)
        {
           /* if (panelGameOver != null){
                panelGameOver.SetActive(true);
            }*/
            transform.position = respawn.position;
            //Player.Rotation = Quaternion.EulerRotation(0, 0, 0);
            lives -= 1;
        }
    }
}
