using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using Class;
using Core;
using Core.SceneSystem;
using Dialog;
using Interface;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GamePlayStrategy
{
    public class SelectionStrategy:IGamePlayStrategy
    {
        private GamePlaySystem _gamePlaySystem;
        
        private ActorText _actorText;
        private ActorIMG _actorImg;
        private List<Selection> _selections;

        private int PlayerSelectNum,SelectionNow,AnswerNum;
        private bool canPick;

        public void init(GamePlaySystem gamePlaySystem)
        {
            switch (GameManager.Instance.CurrentState)
            {
                case MainGameState.Su:
                    _actorText = gamePlaySystem.SuActorText;
                    _actorImg = gamePlaySystem.SuActorImg;
                    break;
                case MainGameState.Fan:
                    _actorText = gamePlaySystem.FanActorText;
                    _actorImg = gamePlaySystem.FanActorImg;
                    break;
                default:
                    //for testing
                    _actorText = gamePlaySystem.SuActorText;
                    _actorImg = gamePlaySystem.SuActorImg;
                    break;
            }

            _selections =
                gamePlaySystem._textReader.GetSortSelectionData(_actorText.GetSelectionPath, _actorText.GetAnswerPath);
            SetupText(gamePlaySystem._dialogManager);
            SetupView(gamePlaySystem._viewManager);
            gamePlaySystem.Favoraty = 0;
            PlayerSelectNum = 0;
            SelectionNow = 0;
            AnswerNum = 0;
            _gamePlaySystem = gamePlaySystem;
            canPick = false;
            
            InputSystem.Instance.BindNewAction(PickL,PickR);
            SelectionState();
        }

        public void update(GamePlaySystem gamePlaySystem)
        {
            
        }


        void SelectionState()
        {
            _gamePlaySystem._viewManager.SetSelectorUIActive(true);
            _gamePlaySystem._viewManager.SetFeverUIActive(false);
            PlayerSelectNum = 0;
            AnswerNum = Random.Range(1, 3);
            switch (AnswerNum)
            {
                case 1:
                    _gamePlaySystem._selectorManager.SetLeftText(_selections[SelectionNow].RightSelection);
                    _gamePlaySystem._selectorManager.SetRightText(_selections[SelectionNow].WrongSelection);
                    break;
                case 2:
                    _gamePlaySystem._selectorManager.SetRightText(_selections[SelectionNow].RightSelection);
                    _gamePlaySystem._selectorManager.SetLeftText(_selections[SelectionNow].WrongSelection);
                    break;
            }
            
            canPick = true;
        }

        void Judgment()
        {
            if (PlayerSelectNum != 0)
            {
                if (PlayerSelectNum == AnswerNum)
                {
                    _gamePlaySystem.Favoraty += 5;
                    _gamePlaySystem._dialogManager.SetDialog(_selections[SelectionNow].RightAnswer);
                    _gamePlaySystem._viewManager.SetActor(_actorImg.RightActor);
                }
                else
                {
                    _gamePlaySystem._dialogManager.SetDialog(_selections[SelectionNow].WrongAnswer);
                    _gamePlaySystem._viewManager.SetActor(_actorImg.WrongActor);
                }

                _gamePlaySystem._viewManager.SetSelectorUIActive(false);
            }
            
            if (SelectionNow < _selections.Count-1)
            {
                SelectionNow++;
                SelectionState();
            }
            else
            {
                _gamePlaySystem.SwitchGamePlayState(_gamePlaySystem.FeverStartegy);
            }
            
        }

        
        void PickL() { if (canPick)PlayerSelectNum = 1;canPick = false;Judgment(); } 
            
        void PickR() { if (canPick)PlayerSelectNum = 2;canPick = false;Judgment(); } 

        #region SetupVoids

        public void SetupText(DialogManager dialogManager)
        {
            dialogManager.SetName(_actorText.myName);
            dialogManager.SetDialog(_actorText.StartText);
        }

        public void SetupView(ViewManager viewManager)
        {
            viewManager.SetActor(_actorImg.RightActor);
            viewManager.SetBackGround(_actorImg.BG[0]);
        }

        #endregion
        
    }
}