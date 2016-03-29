using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    //variables 
    public string SceneChangeName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Load Scene Function
    public void LoadScene()
    {
        Application.LoadLevel(SceneChangeName);
    }
}
