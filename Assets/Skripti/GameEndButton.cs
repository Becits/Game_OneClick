using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndButton : MonoBehaviour {

    public float timeleft = 0;
    public RaycastHit hit;
    public Transform currentButton;
    public Transform cam;
    public LayerMask mask;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && timeleft == 0.0f)
            CheckButton();
    }

    public void CheckButton()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 5, mask))
        {
            currentButton = hit.transform;
            GameObject.Find("Player").SendMessage("Finnish");
        }
    }

}
