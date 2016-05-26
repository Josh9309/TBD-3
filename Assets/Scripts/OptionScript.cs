using UnityEngine;
using System.Collections;

public class OptionScript : MonoBehaviour {

    public GameObject audioCanvas;
    public GameObject displayCanvas;
    public GameObject gameCanvas;
    public GameObject optionCanvas;
    public GameObject creditsCanvas;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchAudio()
    {
        audioCanvas.SetActive(true);
        optionCanvas.SetActive(false);
    }

    public void SwitchGame()
    {
        optionCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void SwitchDisplay()
    {
        optionCanvas.SetActive(false);
        displayCanvas.SetActive(true);
    }

    public void SwitchOption()
    {
        optionCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        displayCanvas.SetActive(false);
        audioCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void SwitchCredits()
    {
        optionCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

}
