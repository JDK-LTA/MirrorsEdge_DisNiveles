// License: Attribution 4.0 International (CC BY 4.0)
/*--- __ECO__ __ACTION__ ---*/
// Source http://hutonggames.com/playmakerforum/index.php?topic=10303.0

using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
	[Tooltip("Clear: Kills all tweens, clears all pools, resets the max Tweeners/Sequences capacities to the default values. ClearCache: Clears all cached tween pools. Validate :Validates all active tweens and removes eventually invalid ones (usually because their target was destroyed). This is a slightly expensive operation so use it with care. Also, no need to use it at all especially if safe mode is ON.")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenClear : FsmStateAction
		{
		[ActionSection("TimeScale Setup")]
		public clearSelect clearType;

		public enum clearSelect {

			Clear, 
			ClearCachedTween,
			Validate, 
		};
			
		public FsmBool clearDestroy;

		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

			
		public override void Reset ()
		{

			clearType = clearSelect.Clear;
			clearDestroy = false;
		}
			
			
			public override void OnEnter()
			{

			switch(clearType){

			case clearSelect.Clear:
				DOTween.Clear(clearDestroy.Value);
				break;

			case clearSelect.ClearCachedTween:
				DOTween.ClearCachedTweens();
				break;

			case clearSelect.Validate:
				DOTween.Validate();
				break;

			}

		


				Finish();

			}


	

			

	}
}