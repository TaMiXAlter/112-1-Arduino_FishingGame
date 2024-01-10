using System.Collections;
using Core;
using Core.SceneSystem;
using Interface;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace GamePlayStrategy
{
    public class FeverStartegy:IGamePlayStrategy
    {
        
        int AnswerNum;
        private float ScaleNum;
        private bool isFever;
        private MonoBehaviour _mono;
        private GamePlaySystem _gamePlaySystem;
        public void init(GamePlaySystem gamePlaySystem)
        {
            gamePlaySystem._viewManager.SetSelectorUIActive(false);
            gamePlaySystem._viewManager.SetFeverUIActive(true);
            gamePlaySystem._AudioManager.PlayFever();
            _mono = gamePlaySystem.GetComponent<MonoBehaviour>();
           InputSystem.Instance.ClearAcction();
           _gamePlaySystem = gamePlaySystem;
           AnswerNum = 0;
           isFever = false;
           ScaleNum = 1;
           
            _mono.StartCoroutine(CountDown(3, _mono, gamePlaySystem));
        }

        IEnumerator CountDown(float Time,MonoBehaviour mono,GamePlaySystem gamePlaySystem)
        {
            if (Time > 1)
            {
                gamePlaySystem._Fevermanager.SetCountDownNum(Time);
                Debug.Log("echo");
                yield return new WaitForSeconds(1);
                float newtime = Time-1;
                mono.StartCoroutine(CountDown(newtime, mono, gamePlaySystem));
            }
            else
            {
                gamePlaySystem._Fevermanager.SetCountDownNum(Time);
                yield return new WaitForSeconds(1);
                mono.StartCoroutine(Fever(10,mono,gamePlaySystem));
            }
        }

        IEnumerator Fever(float Time, MonoBehaviour mono, GamePlaySystem gamePlaySystem)
        {
            InputSystem.Instance.BindNewAction(LP, RP);
            GetARandomArrow(gamePlaySystem);
            isFever = true;
            yield return new WaitForSeconds(Time);
            InputSystem.Instance.ClearAcction();
            isFever = false;
            gamePlaySystem.SwitchGamePlayState(gamePlaySystem.EndupStrategy);
        }

        void GetARandomArrow(GamePlaySystem gamePlaySystem)
        {
            AnswerNum = Random.Range(1, 3);
            switch (AnswerNum)
            {
                case 1 :
                    gamePlaySystem._Fevermanager.ShowLeftArrow(ScaleNum);
                    break;
                case 2 :
                    gamePlaySystem._Fevermanager.ShowRightArrow(ScaleNum);
                    break;
            }
        }

        void LP()
        {
            if (AnswerNum == 1)
            {
                _gamePlaySystem.Favoraty += 5;
                ScaleNum -= ScaleNum/10;
                GetARandomArrow(_gamePlaySystem);
            }
            else if (AnswerNum == 2)
            {
                _gamePlaySystem.Favoraty -= 5;
                GetARandomArrow(_gamePlaySystem);
            }
        }

        void RP()
        {
            if (AnswerNum == 2)
            {
                _gamePlaySystem.Favoraty += 5;
                ScaleNum -= ScaleNum/10;
                GetARandomArrow(_gamePlaySystem);
            }
            else if (AnswerNum == 1)
            {
                _gamePlaySystem.Favoraty -= 5;
                GetARandomArrow(_gamePlaySystem);
            }
        }
    }
}