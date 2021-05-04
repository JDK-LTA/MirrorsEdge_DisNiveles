using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
		[Tooltip("Set DoTween timescale")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenSetTimeScale : FsmStateAction
		{
		[ActionSection("TimeScale Setup")]
		[UIHint(UIHint.FsmFloat)]
		public FsmFloat timeScale;

		[ActionSection("")]
		[Tooltip("Repeat every frame while the state is active.")]
		public FsmBool everyFrame;

		private int select;

		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

			
		public override void Reset ()
		{

			timeScale = 1f;
			everyFrame = false;

		}
			
			
			public override void OnEnter()
			{


			Setup();

			if (!everyFrame.Value)
				Finish();

			}

			public override void OnUpdate()
			{
			Setup();
			}

			
			void Setup(){


			
				DOTween.timeScale = timeScale.Value;

				


		}



			

	}
}