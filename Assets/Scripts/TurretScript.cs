using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public GameObject rotater;
    public GameObject robit;
    internal float rotSpeed; //rotation speed

	// Use this for initialization
	void Start () {
        rotSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        checkRobitPos();
	}

    void checkRobitPos()
    {
        if(robit.transform.position.x < this.transform.position.x) //Robit is to the left of the Turret
        {
            if(rotater.transform.localRotation.y < 180.0f)
            {
                rotater.transform.Rotate(transform.up, -rotSpeed);
            }
        }
        else if (robit.transform.position.x >  this.transform.position.x) //Robit is to the right of the Turret
        {
            if(rotater.transform.localRotation.y < 0)
            {
                rotater.transform.Rotate(transform.up, rotSpeed);
            }
        }
    }
}
