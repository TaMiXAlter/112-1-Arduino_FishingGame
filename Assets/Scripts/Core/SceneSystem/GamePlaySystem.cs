using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using GamePlayStrategy;
using Interface;
using UI;
using UnityEngine;

namespace Core.SceneSystem
{
    public enum GamePlayState
    {
        Selection,
        Fever,
        End
    }
    public class GamePlaySystem : MonoBehaviour
    {
        public ViewManager _viewManager;
        public DialogManager _dialogManager;
        public SelectorManager _selectorManager;
        
        private GamePlayState _gamePlayState;
        
        private SelectionStrategy SelectionStrategy = new SelectionStrategy();
        
        private IGamePlayStrategy CurrentStrategy;

        private void Awake()
        {
            _viewManager = GameObject.Find("Canvas").GetComponent<ViewManager>();
            _dialogManager =  GameObject.Find("Canvas").GetComponent<DialogManager>();
            _selectorManager = GameObject.Find("Canvas").transform.Find("SelecterUI").GetComponent<SelectorManager>();
            
            _gamePlayState = GamePlayState.Selection;
            CurrentStrategy = SelectionStrategy;
            
        }

        private void Update()
        {

        }

        public void SwitchGamePlayState(GamePlayState newState,IGamePlayStrategy newStrategy)
        {
            _gamePlayState = newState;
            CurrentStrategy = newStrategy;
        }
    }
}