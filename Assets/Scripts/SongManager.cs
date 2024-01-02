using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

//	public AudioSource funkymusic;
	public bool startPlaying;
	public BPMHandler songBPM;
	public Text scoreText;
	public Text missText;
	public Text combotxt;
	private int score = 0;
	private int misses = 0;
	private int combo = 0;
	private int resetcombo = 0;
	public static SongManager instance;
    public GameObject sickrating;
    public GameObject shitmiss;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(!startPlaying)
		{
			if(Input.anyKeyDown)
			{
				startPlaying = true;
				songBPM.songStarted = true;
			//	funkymusic.Play();
			}
		}
	}

	public void NoteHit () {
		Debug.Log("Aw yeah you hit it!");
        if(startPlaying)
        {
			sickrating.SetActive(true);
			StartCoroutine(HopAnimation(sickrating.transform, 0.2f, 0.1f));
            score += 350;
			combo += 1;
			scoreText.text = "Score: " + score.ToString();
            combotxt.text = "Combo: " + combo.ToString();
			Invoke("DeactivateSickRating", 1.1f);
        }
	}

	public void NoteMiss () {
        if(startPlaying)
        {
			shitmiss.SetActive(true);
			StartCoroutine(HopAnimation(shitmiss.transform, 0.2f, 0.1f));
            score -= 175; // might switch back to -=10 lol
			misses += 1;
			Debug.Log("Miss" + misses.ToString());
            scoreText.text = "Score: " + score.ToString();
        //    missText.text = "Misses: " + misses.ToString();
            combotxt.text = "Combo: " + resetcombo.ToString();
			Invoke("DeactivateShitMiss", 1.1f);
        }
	}

	private void DeactivateSickRating()
	{
    	sickrating.SetActive(false);
	}

	private void DeactivateShitMiss()
	{
    	shitmiss.SetActive(false);
	}		

    IEnumerator HopAnimation(Transform objTransform, float hopHeight, float duration)
    {
        Vector3 startPos = objTransform.position;
        Vector3 endPos = startPos + Vector3.up * hopHeight;

        float elapsed = 0f;

        while (elapsed < duration)
        {
			float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            objTransform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objTransform.position = endPos;
		objTransform.position = startPos;
    }
}

