using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text Scoretext;
	public Text HighScortext;

	public float ScoreCount;
	public float HighscoreCount;

	public float PointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore"))
		{
			HighscoreCount = PlayerPrefs.GetFloat("HighScore");
		}
	}

	// Update is called once per frame

	void Update () {

		if (scoreIncreasing)
		{
			ScoreCount += PointsPerSecond * Time.deltaTime;
		}
		if(ScoreCount > HighscoreCount)
		{
			HighscoreCount = ScoreCount;
			PlayerPrefs.SetFloat("HighScore", HighscoreCount);
		}

		

		Scoretext.text = "Score: " + Mathf.Round (ScoreCount);
		HighScortext.text = "HighScore: " + Mathf.Round (HighscoreCount);


	}

	public void Addscore(int PointstoAdd)
	{
		ScoreCount += PointstoAdd;
	}

}
