using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
		[Tooltip("Control Panel for all or by ID or by input Id or by gameobject")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenControls : FsmStateAction
		{
		[ActionSection("Controls Setup")]

		public ControlsSelect tagType;

		public enum ControlsSelect {

			All, 
			ByTagId,
			ById, 
			ByGameObjectId,
		};


			
		[ActionSection("Tween ID")]
		[UIHint(UIHint.Tag)]
		[Tooltip("Use Tag as ID")]
		[TitleAttribute("Tag ID")]
		public FsmString tag;
		[UIHint(UIHint.FsmString)]
		[TitleAttribute("Input ID")]
		public FsmString orInputID;
		[UIHint(UIHint.FsmGameObject)]
		[TitleAttribute("GameObject ID")]
		public FsmGameObject gameObject;

		[ActionSection("Controls")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Sends a tween to its end position (has no effect with tweens that have infinite loops).")]
		public FsmBool setComplete;
		[UIHint(UIHint.FsmFloat)]
		[Tooltip("Time position to reach (if higher than the whole tween duration the tween will simply reach its end).")]
		public FsmFloat goToTime;
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Flips the direction of a tween (backwards if it was going forward or viceversa).")]
		public FsmBool setFlip;
		[Tooltip("Play tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool play;
		[Tooltip("Pause tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool pause;
		[Tooltip("Restart tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool restart;
		[Tooltip("Rewind tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool rewind;
		[Tooltip("Smooth Rewind tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool smoothRewind;
		[Tooltip("Play Forward tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool forward;
		[Tooltip("Play Backwards tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool backwards;
		[Tooltip("Kill tween.")]
		[UIHint(UIHint.FsmBool)]
		public FsmBool kill;

		[ActionSection("")]
		[Tooltip("Reset all values on exit")]
		public FsmBool resetOnExit;

	
		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

			
		public override void Reset ()
		{

			orInputID = new FsmString { UseVariable = true };
			tag = new FsmString { UseVariable = true };
			gameObject = new FsmGameObject { UseVariable = true };

			setComplete= false;
			setFlip= false;
			play= false;
			pause= false;
			restart= false;
			rewind= false;
			forward = false;
			backwards = false;
			goToTime= 0f;
			smoothRewind = false;
			kill = false;

		}
			
			
			public override void OnEnter()
			{

			Setup();

			if (resetOnExit.Value){
			setComplete= false;
			setFlip= false;
			play= false;
			pause= false;
			restart= false;
			rewind= false;
			forward = false;
			backwards = false;
			goToTime= 0f;
			smoothRewind = false;
			kill = false;
			}

			Finish();

			}


			void Setup(){

			if (tagType != ControlsSelect.All){
				if (tag.IsNone && orInputID.IsNone && gameObject.IsNone) {

					Debug.LogWarning ("<b>[DotweenControls]</b><color=#FF9900ff>!!! Missing Id data !!! </color>",this.Owner);
			}
			}

			switch(tagType){
				
			case ControlsSelect.All:
				if(setComplete.Value == true) DG.Tweening.DOTween.CompleteAll();
				if(goToTime.Value >0) DG.Tweening.DOTween.GotoAll(goToTime.Value);
				if(setFlip.Value == true) DG.Tweening.DOTween.FlipAll();
				if(play.Value == true) DG.Tweening.DOTween.PlayAll();
				if(pause.Value == true) DG.Tweening.DOTween.PauseAll();
				if(restart.Value == true) DG.Tweening.DOTween.RestartAll();
				if(rewind.Value == true) DG.Tweening.DOTween.RewindAll();
				if(forward.Value == true) DG.Tweening.DOTween.PlayForwardAll();
				if(backwards.Value == true) DG.Tweening.DOTween.PlayBackwardsAll();
				if(smoothRewind.Value == true) DG.Tweening.DOTween.SmoothRewindAll();
				if(kill.Value == true) DG.Tweening.DOTween.KillAll();
				break;
				
			case ControlsSelect.ByTagId:
				if(setComplete.Value == true) DG.Tweening.DOTween.Complete(tag.Value);
				if(goToTime.Value >0) DG.Tweening.DOTween.Goto(tag.Value,goToTime.Value);
				if(setFlip.Value == true) DG.Tweening.DOTween.Flip(tag.Value);
				if(play.Value == true) DG.Tweening.DOTween.Play(tag.Value);
				if(pause.Value == true) DG.Tweening.DOTween.Pause(tag.Value);
				if(restart.Value == true) DG.Tweening.DOTween.Restart(tag.Value);
				if(rewind.Value == true) DG.Tweening.DOTween.Rewind(tag.Value);
				if(forward.Value == true) DG.Tweening.DOTween.PlayForward(tag.Value);
				if(backwards.Value == true) DG.Tweening.DOTween.PlayBackwards(tag.Value);
				if(smoothRewind.Value == true) DG.Tweening.DOTween.SmoothRewind(tag.Value);
				if(kill.Value == true) DG.Tweening.DOTween.Kill(tag.Value);
				break;
				
			case ControlsSelect.ById:
				if(setComplete.Value == true) DG.Tweening.DOTween.Complete(orInputID.Value);
				if(goToTime.Value >0) DG.Tweening.DOTween.Goto(orInputID.Value,goToTime.Value);
				if(setFlip.Value == true) DG.Tweening.DOTween.Flip(orInputID.Value);
				if(play.Value == true) DG.Tweening.DOTween.Play(orInputID.Value);
				if(pause.Value == true) DG.Tweening.DOTween.Pause(orInputID.Value);
				if(restart.Value == true) DG.Tweening.DOTween.Restart(orInputID.Value);
				if(rewind.Value == true) DG.Tweening.DOTween.Rewind(orInputID.Value);
				if(forward.Value == true) DG.Tweening.DOTween.PlayForward(orInputID.Value);
				if(backwards.Value == true) DG.Tweening.DOTween.PlayBackwards(orInputID.Value);
				if(smoothRewind.Value == true) DG.Tweening.DOTween.SmoothRewind(orInputID.Value);
				if(kill.Value == true) DG.Tweening.DOTween.Kill(orInputID.Value);
				break;
				
			case ControlsSelect.ByGameObjectId:
				if(setComplete.Value == true) DG.Tweening.DOTween.Complete(gameObject.Value);
				if(goToTime.Value >0) DG.Tweening.DOTween.Goto(gameObject.Value,goToTime.Value);
				if(setFlip.Value == true) DG.Tweening.DOTween.Flip(gameObject.Value);
				if(play.Value == true) DG.Tweening.DOTween.Play(gameObject.Value);
				if(pause.Value == true) DG.Tweening.DOTween.Pause(gameObject.Value);
				if(restart.Value == true) DG.Tweening.DOTween.Restart(gameObject.Value);
				if(rewind.Value == true) DG.Tweening.DOTween.Rewind(gameObject.Value);
				if(forward.Value == true) DG.Tweening.DOTween.PlayForward(gameObject.Value);
				if(backwards.Value == true) DG.Tweening.DOTween.PlayBackwards(gameObject.Value);
				if(smoothRewind.Value == true) DG.Tweening.DOTween.SmoothRewind(gameObject.Value);
				if(kill.Value == true) DG.Tweening.DOTween.Kill(gameObject.Value);
				break;
				
			}

			return;
		}



			

	}
}