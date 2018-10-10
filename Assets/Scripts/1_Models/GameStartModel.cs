using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStartModel
{
	int numberOfTries { get; }
}

public class GameStartModel : IGameStartModel
{
	public GameStartModel (int numberOfTries) {
		this.numberOfTries = numberOfTries;
	}
	public int numberOfTries { get; private set; }
}