using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    public GameObject h2pCanvas;

    public void FreeplayScene()
    {
		//SceneManager.LoadScene("Freeplay");
        SceneManager.LoadScene("Debug"); // Until I make a freeplay menu load into the debug song.
	}

    public void Options()
    {
		mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
	}

	public void H2P()
	{
		mainCanvas.SetActive(false);
        h2pCanvas.SetActive(true);
	}

	public void OPBack()
	{
		mainCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
	}

    public void H2PBack()
	{
		mainCanvas.SetActive(true);
        h2pCanvas.SetActive(false);
	}
}