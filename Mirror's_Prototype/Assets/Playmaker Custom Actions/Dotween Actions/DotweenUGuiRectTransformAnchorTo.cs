﻿// License: Attribution 4.0 International (CC BY 4.0)
/*--- __ECO__ __ACTION__ ---*/
// Source http://hutonggames.com/playmakerforum/index.php?topic=10303.0


using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
		[Tooltip("Tweens the target's anchoredPosition in 2D or 3D")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenUGuiRectTransformAnchorTo : FsmStateAction
		{
			[ActionSection("Setup")]
			[RequiredField]
			public FsmOwnerDefault gameObject;


		public enum doTweenType  {
			
			AnchoredPosition2D,
			AnchoredPosition3D,
			AnchoredPositionY,
			AnchoredPositionX,
			
		};
		
		public doTweenType dotweenTypeSelect;
	 

			[ActionSection("Vector3 Setup")]
			[UIHint(UIHint.FsmVector3)]
			public FsmVector3 setTo;
			[UIHint(UIHint.FsmVector2)]
			public FsmVector2 set2DTo;
			[UIHint(UIHint.FsmFloat)]
			[Tooltip("Translation along x axis.")]
			public FsmFloat x;
			[UIHint(UIHint.FsmFloat)]
			[Tooltip("Translation along y axis.")]
			public FsmFloat y;
			[UIHint(UIHint.FsmFloat)]
			[Tooltip("Translation along z axis.")]
			public FsmFloat z;

			[ActionSection("Time Setup")]
			public FsmFloat duration;
			[UIHint(UIHint.FsmBool)]
			[Tooltip("If isSpeedBased is TRUE sets the tween as speed based (the duration will represent the number of units/degrees the tween moves x second). ")]	
			public FsmBool isSpeedBased;
			[UIHint(UIHint.FsmBool)]
			[Tooltip("If True, will ignore Unity Timescale")]	
			public FsmBool isTimeIndependent;
		
			[ActionSection("Ease Setup")]

			public setEaseType easeTypeSelect;
			public enum setEaseType
			{
			none,
			AnimationCurve,
			InSine,
			OutSine,
			InOutSine,
			InQuad,
			OutQuad,
			InOutQuad,
			InCubic,
			OutCubic,
			InOutCubic,
			InQuart,
			OutQuart,
			InOutQuart,
			InQuint,
			OutQuint,
			InOutQuint,
			InExpo,
			OutExpo,
			InOutExpo,
			InCirc,
			OutCirc,
			InOutCirc,
			InElastic,
			OutElastic,
			InOutElastic,
			InBack,
			OutBack,
			InOutBack,
			InBounce,
			OutBounce,
			InOutBounce,
			Flash,
			InFlash,
			OutFlash,
			InOutFlash,
			};


		[Tooltip("Only works if ease is set to curve!)")]
		public FsmAnimationCurve animationCurve;

		[ActionSection("Ease Extra Layer Setup")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("extra layer you can add to your easings, making them behave as if they were playing in stop-motion")]
		public FsmBool enableEaseFactory;
		[UIHint(UIHint.FsmInt)]
		public FsmInt easeFactoryFps;
	
		[ActionSection("Tween ID")]
		[UIHint(UIHint.Tag)]
		[Tooltip("Set ID to Tag")]
		[TitleAttribute("Use Tag as ID")]
		public FsmString tag;
		[UIHint(UIHint.FsmString)]
		[TitleAttribute("Input new ID")]
		public FsmString orInputID;
		[UIHint(UIHint.FsmBool)]
		[TitleAttribute("GameObject as ID")]
		public FsmBool gameObjectId;

		[ActionSection("Loop")]
		public FsmBool loopDontFinish;
		[Tooltip("Setting loops to -1 will make the tween loop infinitely. ")]
		[TitleAttribute("Set Loop quantity")]
		public FsmInt loopsQuantity;
		private int settingLoops;
		public enum loopType
		{
			None,
			Restart,
			Yoyo,
			Incremental,
		};
		
		public loopType loopTypeSelect;

		[ActionSection("Other Settings")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("If TRUE the tween will smoothly snap all values to integers.")]	
		public FsmBool snapping;
		[UIHint(UIHint.FsmBool)]
		[Tooltip("If TRUE sets the tween as relative (the endValue will be calculated as startValue + endValue instead of being used directly). ")]	
		public FsmBool setRelative;
		[UIHint(UIHint.FsmFloat)]
		[HasFloatSlider(0,10)]
		public FsmFloat setDelay;
	

		public enum updateType
		{
			Normal,
			Late,
			Fixed,
		};
		
		public updateType updateTypeSelect;


		[ActionSection("Events")]
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Will set to TRUE when Tween is finished")]
		[Title("is finished")]
		public FsmBool DotweenDone;
		[Tooltip("If TRUE the tween will be killed as soon as it completes, otherwise it will stay in memory and you'll be able to reuse it.")]
		[Title("Kill on Exit")]
		public FsmBool setAutoKill;
		[Tooltip("If TRUE the tween will be recycled after being killed, otherwise it will be destroyed.")]
		public FsmBool setRecycle;
		public FsmEvent startEvent;
		public FsmEvent finishEvent;

	
		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

		private TweenParams setLoopData;
		private TweenParams setID;
		private TweenParams setEase;
		private TweenParams setUpdate;
		TweenParams setFinal;

		private string debugString = "<b>[DotweenUGuiRectTransformAnchorTo]</b><color=#E9E581ff> ...mmm did 'DoTween' work ?? </color>";

		private Vector2 Vector2setup;
		private Vector3 Vector3setup;

		public override void Reset ()
		{

				duration = 0f;
				setDelay = 0f;
				x = new FsmFloat { UseVariable = true };
				y = new FsmFloat { UseVariable = true };
				z = new FsmFloat { UseVariable = true };
				isSpeedBased = false;
				settingLoops = 0;
				enableEaseFactory = false;
				easeFactoryFps = 0;
			 	setRelative=false;
				DotweenDone = false;
				setAutoKill = false;
				orInputID = new FsmString { UseVariable = true };
				tag = new FsmString { UseVariable = true };
				gameObjectId = new FsmBool { UseVariable = true };
				startEvent = null;
				finishEvent = null;
				loopDontFinish = false;
				setTo = null;
				snapping = false;
				Vector3setup = new Vector3(0,0,0);
				Vector2setup  = new Vector2(0,0);
				loopsQuantity = 0;
				isTimeIndependent = false;
				setRecycle = false;
		}
			
			
			public override void OnEnter()
			{
				
				var _target = Fsm.GetOwnerDefaultTarget(gameObject);

			if (_target != null && dotweenTypeSelect != doTweenType.AnchoredPosition3D)
			{
				
				Vector2setup = set2DTo.IsNone ? new Vector2(x.Value, y.Value) : set2DTo.Value;
				
				if (!x.IsNone) Vector2setup.x = x.Value;
				if (!y.IsNone) Vector2setup.y = y.Value;

			
			}

			if (_target != null && dotweenTypeSelect == doTweenType.AnchoredPosition3D)
			{
				
				Vector3setup = setTo.IsNone ? new Vector3(x.Value, y.Value, z.Value) : setTo.Value;
				
				if (!x.IsNone) Vector3setup.x = x.Value;
				if (!y.IsNone) Vector3setup.y = y.Value;
				if (!z.IsNone) Vector3setup.z = z.Value;	

			
			}

			if (loopDontFinish.Value == true) settingLoops = -1;
			else settingLoops = loopsQuantity.Value;

			setFinal = new TweenParams().SetDelay(setDelay.Value).SetAutoKill(setAutoKill.Value).SetSpeedBased(isSpeedBased.Value).SetRelative(setRelative.Value).OnComplete(MyCallback);



			switch(loopTypeSelect){
			case loopType.None:
				if (settingLoops > 0 || settingLoops < 0) Debug.LogWarning ("<b>[DotweenUGuiRectTransformAnchorTo]</b><color=#FF9900ff>!!! Loop Time is set but no 'Loop Type' is selected !!! </color>",this.Owner);
				break;

			case loopType.Yoyo:
				setFinal.SetLoops(settingLoops, LoopType.Yoyo);
				break;

			case loopType.Restart:
				setFinal.SetLoops(settingLoops, LoopType.Restart);
				break;

			case loopType.Incremental:
				setFinal.SetLoops(settingLoops, LoopType.Incremental);
				break;

			}



			if (!tag.IsNone)
				setFinal.SetId(tag.Value);
			bool _isNullOrEmpty = orInputID.IsNone || orInputID == null || string.IsNullOrEmpty (orInputID.Value);
			if (_isNullOrEmpty == false)
				setFinal.SetId(orInputID.Value);
			bool obj_isNullOrEmpty = gameObjectId.IsNone|| gameObjectId.Value == false;
			if (obj_isNullOrEmpty == false)
				setFinal.SetId(Fsm.GetOwnerDefaultTarget(gameObject));



			switch(easeTypeSelect){
			case setEaseType.none:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.Linear);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.Linear));
				break;
			
			case setEaseType.InSine:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InSine);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InSine));
				break;
			case setEaseType.OutSine:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutSine);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutSine));
				break;
			case setEaseType.InOutSine:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutSine);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutSine));
				break;
			case setEaseType.InQuad:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InQuad);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InQuad));
				break;
			case setEaseType.OutQuad:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutQuad);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutQuad));
				break;
			case setEaseType.InOutQuad:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutQuad);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutQuad));
				break;
			case setEaseType.InCubic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InCubic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InCubic));
				break;
			case setEaseType.OutCubic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutCubic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutCubic));
				break;
			case setEaseType.InOutCubic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutCubic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutCubic));
				break;
			case setEaseType.InQuart:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InQuart);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InQuart));
				break;
			case setEaseType.OutQuart:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutQuart);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutQuart));
				break;
			case setEaseType.InOutQuart:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutQuart);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutQuart));
				break;
			case setEaseType.InQuint:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InQuint);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InQuint));
				break;
			case setEaseType.OutQuint:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutQuint);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutQuint));
				break;
			case setEaseType.InOutQuint:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutQuint);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutQuint));
				break;
			case setEaseType.InExpo:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InExpo);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InExpo));
				break;
			case setEaseType.OutExpo:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutExpo);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutExpo));
				break;
			case setEaseType.InOutExpo:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutExpo);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutExpo));
				break;
			case setEaseType.InCirc:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InCirc);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InCirc));
				break;
			case setEaseType.OutCirc:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutCirc);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutCirc));
				break;
			case setEaseType.InOutCirc:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutCirc);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutCirc));
				break;
			case setEaseType.InElastic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InElastic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InElastic));
				break;
			case setEaseType.OutElastic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutElastic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutElastic));
				break;
			case setEaseType.InOutElastic:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutElastic);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutElastic));
				break;
			case setEaseType.InBack:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InBack);
				if (enableEaseFactory.Value == true)setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InBack));
				break;
			case setEaseType.OutBack:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutBack);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutBack));
				break;
			case setEaseType.InOutBack:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutBack);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutBack));
				break;
			case setEaseType.InBounce:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InBounce);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InBounce));
				break;
			case setEaseType.OutBounce:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutBounce);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutBounce));
				break;

			case setEaseType.InOutBounce:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutBounce);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutBounce));
				break;
			
			case setEaseType.Flash:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.Flash);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.Flash));
				break;

			case setEaseType.InFlash:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InFlash);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InFlash));
				break;

			case setEaseType.OutFlash:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.OutFlash);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.OutFlash));
				break;

			case setEaseType.InOutFlash:
				if (enableEaseFactory.Value == false) setFinal.SetEase( Ease.InOutFlash);
				if (enableEaseFactory.Value == true) setFinal.SetEase(EaseFactory.StopMotion(easeFactoryFps.Value, Ease.InOutFlash));
				break;

			case setEaseType.AnimationCurve:
				setFinal.SetEase(animationCurve.curve);
				break;

			
			}

			// Update + TimeScale
			
			switch(updateTypeSelect){
				
			case updateType.Normal:
				setFinal.SetUpdate(UpdateType.Normal,isTimeIndependent.Value);
				break;
				
			case updateType.Fixed:
				setFinal.SetUpdate(UpdateType.Fixed,isTimeIndependent.Value);
				break;
				
			case updateType.Late:
				setFinal.SetUpdate(UpdateType.Late,isTimeIndependent.Value);
				break;
				
			}


			// Easy part to edit for other DotTween actions --->


			switch(dotweenTypeSelect){

			case doTweenType.AnchoredPosition2D:
				_target.GetComponent<RectTransform>().DOAnchorPos(Vector2setup,duration.Value, snapping.Value).SetAs(setFinal);
				break;
				
			case doTweenType.AnchoredPosition3D:
				_target.GetComponent<RectTransform>().DOAnchorPos3D(Vector3setup,duration.Value, snapping.Value).SetAs(setFinal);
				break;

			case doTweenType.AnchoredPositionX:
				_target.GetComponent<RectTransform>().DOAnchorPosX(Vector2setup.x,duration.Value, snapping.Value).SetAs(setFinal);
				break;

			case doTweenType.AnchoredPositionY:
				_target.GetComponent<RectTransform>().DOAnchorPosY(Vector2setup.y,duration.Value, snapping.Value).SetAs(setFinal);
				break;
			}

			// <--- 


			if(startEvent != null){
				Fsm.Event(startEvent);
				Finish();
			}

		}
			
			public override void OnExit()
			{
			if (DotweenDone.Value != true && startEvent == null && (loopTypeSelect == loopType.None)) Debug.LogWarning (debugString,this.Owner);
			}
			
			void MyCallback()
		{
			DotweenDone.Value = true;

			if(finishEvent != null){
				Fsm.Event(finishEvent);
			}
			Finish();
			return;
			
		}
		}
		
	}