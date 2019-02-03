using UnityEngine;
using System.Collections;

public class GameScore
{
	private static GameScore GameScoreInstance = null;
	public static GameScore SharedGameScore
	{
		get
		{
			if (GameScoreInstance == null)
			{
				GameScoreInstance = new GameScore();
			}
			return GameScoreInstance;
		}
	}
	public float gameScore = 0;
}