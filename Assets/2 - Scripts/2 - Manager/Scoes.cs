using UnityEngine;

public static class Score
{
	public static int GetScore()
	{
		if (PlayerPrefs.HasKey("Score"))
		{
			return PlayerPrefs.GetInt("Score");
		}

		return 0;
	}

	public static void SaveScore(int score)
	{
		if (!PlayerPrefs.HasKey("Score"))
		{
			PlayerPrefs.SetInt("Score", score);
			return;
		}


		if (score > GetScore())
		{
			PlayerPrefs.SetInt("Score", score);
		}
	}

	public static void ResetScore()
	{
		PlayerPrefs.DeleteKey("Score");
	}
}
