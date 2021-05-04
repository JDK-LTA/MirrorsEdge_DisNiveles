using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
		[Tooltip("Control global settings")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenGlobalSettings : FsmStateAction
		{
		[ActionSection("ErrorLog")]

		[UIHint(UIHint.FsmBool)]
		[Tooltip("If set to TRUE you will get a DOTween report when exiting play mode (only in the Editor).Will slow slightly slow down Unity Editor.")]
		public FsmBool showUnityReport;
		public ControlsSelect logError;

		public enum ControlsSelect {

			ErrorsOnly, 
			Default,
			Verbose, 
		};

		[ActionSection("Time")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Sets whether Unity's timeScale should be taken into account by default or not.")]
		public FsmBool setTimescaleIndepedent;
		[UIHint(UIHint.FsmFloat)]
		[Tooltip("Global timeScale applied to all tweens, both regular and independent..")]
		public FsmFloat setTimescale;
		[UIHint(UIHint.FsmBool)]
		public FsmBool useSmoothDelta;
		[ActionSection("Other")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("If set to TRUE tweens will be slightly slower but safer, allowing DOTween to automatically take care of things like targets being destroyed while a tween is running.")]
		public FsmBool useSafeMode;
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Default autoKill behaviour applied to all newly created tweens.")]
		public FsmBool defaultAutoKillAll;
		[Tooltip("Default autoPlay behaviour applied to all newly created tweens.")]
		public Autoplay setAutoPlay;
		public enum Autoplay {
		 
			All,
			None, 
			AutoPlaySequences,
			AutoPlayTweeners,
		};
		[Tooltip("Default overshoot/amplitude used for eases.")]
		public FsmFloat setEaseOvershoot;
		[Tooltip("Default period used for eases.")]
		public FsmFloat setDefaultEasePeriod;


		[Tooltip("In order to be faster DOTween limits the max amount of active tweens you can have. If you go beyond that limit don't worry: it is automatically increased. ")]
		public FsmInt setTweenCapacityMax;
		public FsmInt setTweenCapacityMin;

		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

			
		public override void Reset ()
		{
			
			logError = ControlsSelect.Default;
			showUnityReport= false;
			useSafeMode= true;
			setTimescale= 1f;
			defaultAutoKillAll = false;
			setAutoPlay = Autoplay.All;
			setEaseOvershoot = 1.70158f;
			setDefaultEasePeriod = 0f;
			setTimescaleIndepedent = false;
			setTweenCapacityMax = 2000;
			setTweenCapacityMin = 100;
			useSmoothDelta = false;
		
		}
			
			
			public override void OnEnter()
			{

			Setup();

			Finish();

			}


			void Setup(){
			
			switch(logError){
				
			case ControlsSelect.Default:
				DOTween.logBehaviour = LogBehaviour.Default;
				break;
				
			case ControlsSelect.Verbose:
				DOTween.logBehaviour = LogBehaviour.Verbose;
				break;
				
			case ControlsSelect.ErrorsOnly:
				DOTween.logBehaviour = LogBehaviour.ErrorsOnly;
				break;
				
			}

			DOTween.showUnityEditorReport = showUnityReport.Value;
			DOTween.useSafeMode = useSafeMode.Value;
			DOTween.timeScale = setTimescale.Value;
			DOTween.defaultAutoKill = defaultAutoKillAll.Value;

			switch(setAutoPlay){

			case Autoplay.All:
				DOTween.defaultAutoPlay = AutoPlay.All;
				break;

			case Autoplay.None:
				DOTween.defaultAutoPlay = AutoPlay.None;
				break;

			case Autoplay.AutoPlaySequences:
				DOTween.defaultAutoPlay = AutoPlay.AutoPlaySequences;
				break;

			case Autoplay.AutoPlayTweeners:
				DOTween.defaultAutoPlay = AutoPlay.AutoPlayTweeners;
				break;
			}

			DOTween.defaultEaseOvershootOrAmplitude = setEaseOvershoot.Value;
			DOTween.defaultEasePeriod = setDefaultEasePeriod.Value;
			DOTween.defaultTimeScaleIndependent = setTimescaleIndepedent.Value;
			DOTween.SetTweensCapacity(setTweenCapacityMax.Value,setTweenCapacityMin.Value);
			DOTween.useSmoothDeltaTime = useSmoothDelta.Value;

			return;
		}



			

	}
}