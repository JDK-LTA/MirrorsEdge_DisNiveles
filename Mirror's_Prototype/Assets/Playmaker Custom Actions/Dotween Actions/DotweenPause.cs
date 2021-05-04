using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace HutongGames.PlayMaker.Actions
{
	
		[ActionCategory("Dotween Actions")]
		[Tooltip("Pause all or by ID ")]
		[HelpUrl("http://dotween.demigiant.com/documentation.php")]
		public class DotweenPause : FsmStateAction
		{
		[ActionSection("Controls Setup")]

		public pauseSelect tagType;

		public enum pauseSelect {

			PauseAll, 
			PauseByTagId,
			PauseById, 
			PauseByGameObject,
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
		public FsmBool pauseEnable;

		[ActionSection("")]
		[Tooltip("Repeat every frame while the state is active.")]
		public FsmBool everyFrame;

		int select;
	
		[ActionSection("")]
		[UIHint(UIHint.Description)]
		public string descriptionArea = "Minimum Dotween version requirement: v1.1.310";

			
		public override void Reset ()
		{

			orInputID = new FsmString { UseVariable = true };
			tag = new FsmString { UseVariable = true };
			gameObject = new FsmGameObject { UseVariable = true };
			pauseEnable = true;
			everyFrame = false;

		}
			
			
			public override void OnEnter()
			{


			switch(tagType){

			case pauseSelect.PauseAll:
				select = 1;
				break;

			case pauseSelect.PauseById:
				select = 2;
				break;

			case pauseSelect.PauseByTagId:
				select = 3;
				break;

			case pauseSelect.PauseByGameObject:
				select = 4;
				break;


			}


			Setup();

			if (!everyFrame.Value)
				Finish();

			}

			public override void OnUpdate()
			{
			Setup();
			}

			
			void Setup(){

			if (tagType != pauseSelect.PauseAll){
				if (tag.IsNone && orInputID.IsNone && gameObject.IsNone) {

					Debug.LogWarning ("<b>[DotweenPause]</b><color=#FF9900ff>!!! Missing Id data !!! </color>",this.Owner);
				}
			}
			
			if (select == 1 && pauseEnable.Value == false)
			{
			
					DG.Tweening.DOTween.PlayAll();

			}

			if (select == 1 && pauseEnable.Value == true)
			{
					DG.Tweening.DOTween.PauseAll();
			
			}



			if (select == 2 && pauseEnable.Value == false)
			{
			
				DG.Tweening.DOTween.Play(orInputID.Value);

			}
			
			if (select == 2 && pauseEnable.Value == true)
			{
				DG.Tweening.DOTween.Pause(orInputID.Value);
			
			}

			if (select == 3 && pauseEnable.Value == false)
			{
				
				DG.Tweening.DOTween.Play(tag.Value);
				
			}
			
			if (select == 3 && pauseEnable.Value == true)
			{
				DG.Tweening.DOTween.Pause(tag.Value);
				
			}



			if (select == 4 && pauseEnable.Value == false)
			{
			
				DG.Tweening.DOTween.Play(gameObject.Value);

			}
			
			if (select == 4 && pauseEnable.Value == true)
			{
				DG.Tweening.DOTween.Pause(gameObject.Value);

			}



		}



			

	}
}