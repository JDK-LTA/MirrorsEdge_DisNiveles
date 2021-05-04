using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public class DeltaAngle : FsmStateAction
    {
        public FsmGameObject root;
        public FsmFloat StoreValue;

        float turn;
        Transform Root;

        float prevBody, currentBody;

        public override void OnUpdate()
        {
            doThing();
        }

        void doThing()
        {
            Root = root.Value.transform;


            prevBody = currentBody;
            currentBody = Root.eulerAngles.y;

            float targetTurn = Mathf.DeltaAngle(prevBody, currentBody);
            turn = Mathf.Lerp(turn, targetTurn, Time.smoothDeltaTime * 10f);
            StoreValue.Value = turn;
        }
    }
}

