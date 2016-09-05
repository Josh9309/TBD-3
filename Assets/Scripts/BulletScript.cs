using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private GameObject[] turrets;
    private Collider bulletCol;
    public float bulletDam = 25;

	// Use this for initialization
	void Start () {
        turrets = GameObject.FindGameObjectsWithTag("turretGun");
        bulletCol = GetComponent<Collider>();

        Debug.Log("Turret Length: " + turrets.Length);
        for(int i =0; i < turrets.Length; i++)
        {
            Physics.IgnoreCollision(turrets[i].GetComponent<Collider>(), bulletCol);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < turrets.Length; i++)
        {
            Physics.IgnoreCollision(turrets[i].GetComponent<Collider>(), bulletCol);
        }
    }

    //Changing to a trigger collision
    //void OnCollisionEnter(Collision collisionInfo)
    //{
    //    GameObject robit = GameObject.Find("Robit");
    //    robit.GetComponent<Robit_Player>().health -= bulletDam;
    //    print("Detected collison between " + gameObject.name + " and " + collisionInfo.collider.name);
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject robit = GameObject.Find("Robit");
            robit.GetComponent<Robit_Player>().health -= bulletDam;
            print("Robit was hit; Current Health: " + robit.GetComponent<Robit_Player>().health);
        }
        print("Detected collison between " + gameObject.name + " and " + other.name);
        Destroy(gameObject);
    }
}
