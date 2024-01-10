using System.Collections;
using Core;
using Core.SceneSystem;
using Interface;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace GamePlayStrategy
{
    enum State
    {
        CountDown,
        Game
    }
    public class FeverStartegy:IGamePlayStrategy
    {
        
        int PlayerSelect = 0;
        private int CountDownNum = 3;
        private State currentState = State.CountDown;
        private MonoBehaviour _mono;
        public void init(GamePlaySystem gamePlaySystem)
        {
            Debug.Log("FEVER");
            gamePlaySystem._viewManager.SetSelectorUIActive(false);
            gamePlaySystem._viewManager.SetFeverUIActive(true);
            _mono = gamePlaySystem.GetComponent<MonoBehaviour>();
            InputSystem.Instance.BindNewAction(LP, RP);
            _mono.StartCoroutine(test());
        }

        public void update(GamePlaySystem gamePlaySystem)
        {
            
        }

        IEnumerator test()
        {
            yield return new WaitForSeconds(1);
            Debug.Log("mono init");
        }

        void LP() => PlayerSelect = 1;
        void RP() => PlayerSelect = 2;
    }
}