using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models 
{
	public class GameResultModel : IGameResultModel 
	{
		private readonly int _stage;
		private readonly bool _hasWon;

		public GameResultModel (int stage, bool hasWon) {
			_stage = stage;
			_hasWon = hasWon;
		}

		#region IGameResultModel
			public int Stage {
				get { return _stage; }
			}

			public bool HasWon {
				get { return _hasWon; }
			}
		#endregion
	}
}
