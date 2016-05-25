using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public GameObject rotater;
    public GameObject robit;
    public GameObject gun;
    public GameObject barrel;

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
        ////Checks to determine if it should rotate left or right
        //if(robit.transform.position.x < this.transform.position.x) //Robit is to the left of the Turret
        //{
        //    Debug.Log("y: " + rotater.transform.localEulerAngles.y);
        //    if(rotater.transform.localEulerAngles.y > 180.0f || rotater.transform.localEulerAngles.y == 0)
        //    {
        //        rotater.transform.Rotate(transform.up, -rotSpeed);
        //    }
        //}
        //else if (robit.transform.position.x >  this.transform.position.x) //Robit is to the right of the Turret
        //{
        //    if(rotater.transform.localEulerAngles.y > 0)
        //    {
        //        rotater.transform.Rotate(transform.up, rotSpeed);
        //    }
        //    if(rotater.transform.localEulerAngles.y < 0)
        //    {
        //        rotater.transform.localRotation = Quaternion.Euler(rotater.transform.localRotation.x, 0, rotater.transform.localEulerAngles.z);
        //    }
        //}

        ////Checks to determine if it should rotate up or down
        //if (robit.transform.position.y < barrel.transform.position.y) //Robbit is bellow gun barrel
        //{
        //    Debug.Log("z: " + gun.transform.localEulerAngles.z);
        //    if(gun.transform.localEulerAngles.z > 342 || gun.transform.localEulerAngles.z <= 17)
        //    {
        //        gun.transform.Rotate(transform.forward, -1);
        //    }
        //}
        //else if (robit.transform.position.y > barrel.transform.position.y)//Robit is  above gun barrel
        //{
        //    Debug.Log("z: " + gun.transform.localEulerAngles.z);
        //    if (gun.transform.localEulerAngles.z < 15 || gun.transform.localEulerAngles.z  >=340)
        //    {
        //        gun.transform.Rotate(transform.forward, rotSpeed);
        //    }

        //}

        Vector3 rotaterTar = robit.transform.position - rotater.transform.position;
        rotaterTar.y = 0;


        Quaternion rotaterQuatTar = Quaternion.LookRotation(rotaterTar, Vector3.up);
        rotater.transform.rotation = Quaternion.RotateTowards(rotater.transform.rotation, rotaterQuatTar, rotSpeed);

        Vector3 gunTar = robit.transform.position; //sets gun target to robits position
        gunTar.x = 0;// sets the x to 0 so it will not rotate on the x axis

        gun.transform.LookAt(robit.transform, Vector3.up); //rotates the gun to look at robit

        //code that was not working properly Saving to examine it later
        //Quaternion gunQuatTar = Quaternion.LookRotation(gunTar);
        //gun.transform.localRotation = Quaternion.RotateTowards(gun.transform.localRotation, gunQuatTar, rotSpeed);




    }
}
