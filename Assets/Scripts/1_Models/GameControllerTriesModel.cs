using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models 
{
	[Serializable]
	public class GameControllerTriesModel : IGameControllerTriesModel
	{
		public int tries;
		public int triesRange;

		public int Tries { get { return tries; } }
		public int TriesRange { get { return triesRange; } }
	}
}
