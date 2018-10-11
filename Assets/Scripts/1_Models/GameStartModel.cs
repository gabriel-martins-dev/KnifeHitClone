using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models 
{
	public class GameStartModel : IGameStartModel
	{
		public GameStartModel (int numberOfTries) {
			this.numberOfTries = numberOfTries;
		}
		public int numberOfTries { get; private set; }
	}
}