using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    public GameObject prey; //this is what the camera will follow
    public float sepDist = 10.0f;
    public float yDist = 10.0f;
    internal float zPos;
    internal float yPos;
	
    // Use this for initialization
	void Start () {
        zPos = prey.transform.position.z - sepDist;
        yPos = prey.transform.position.y + yDist;
	}
	
	// Update is called once per frame
	void Update (){

        // Set the position of the camera 
        Vector3 wantedPosition = new Vector3(prey.transform.position.x, prey.transform.position.y+yDist, zPos);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 2.0f);
    }
}
