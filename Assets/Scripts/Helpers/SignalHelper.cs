using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.helpers
{
	public static class Signals 
	{
		public static string GameStartPhase () 
		{
			return "GAME_START_PHASE";
		}

		public static string GameWinPhase () 
		{
			return "GAME_WIN_PHASE";
		}

		public static string GameLostPhase () 
		{
			return "GAME_LOST_PHASE";
		}

		public static string GameResultPhase () 
		{
			return "GAME_RESULT_PHASE";
		}

		public static string TargetReady () 
		{
			return "TARGET_READY";
		}

		public static string TargetOut () 
		{
			return "TARGET_OUT";
		}

		public static string UpdateAttackTries () 
		{
			return "UPDATE_ATTACK_TRIES";
		}

		public static string GameResult () 
		{
			return "GAME_RESULT";
		}

		public static string ThrowKnive () 
		{
			return "THROW_KNIVE";
		}

		public static string StartAttack () 
		{
			return "START_ATTACK";
		}

		public static string AttackSucces () 
		{
			return "ATTACK_SUCCESS";
		}

		public static string AttackFailed () 
		{
			return "ATTACK_FAILED";
		}
	}
}