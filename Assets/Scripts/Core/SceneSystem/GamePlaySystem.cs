using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Class;
using Dialog;
using GamePlayStrategy;
using Interface;
using UI;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace Core.SceneSystem
{
    public class GamePlaySystem : MonoBehaviour
    {
        public ActorText SuActorText, FanActorText;
        public ActorIMG SuActorImg, FanActorImg;

        
        #region GetAssest
        [HideInInspector] public TextReader _textReader = new TextReader();
        [HideInInspector] public ViewManager _viewManager;
        [HideInInspector] public DialogManager _dialogManager;
        [HideInInspector] public SelectorManager _selectorManager;
        [HideInInspector] public FeverManager _Fevermanager;
        #endregion

        #region Strategys

        public SelectionStrategy SelectionStrategy = new SelectionStrategy();
        public FeverStartegy FeverStartegy = new FeverStartegy();

        #endregion
        
        private IGamePlayStrategy CurrentStrategy;

        public int Favoraty;
        private void Awake()
        {
            _viewManager = GameObject.Find("Canvas").GetComponent<ViewManager>();
            _dialogManager =  GameObject.Find("Canvas").GetComponent<DialogManager>();
            _selectorManager = GameObject.Find("Canvas").transform.Find("SelecterUI").GetComponent<SelectorManager>();
        }

        private void Start()
        {
            SwitchGamePlayState( SelectionStrategy);
        }

        private void Update()
        {
            // CurrentStrategy.update(this);
            _viewManager.SetFavorabilityNum(Favoraty);
        }

        public void SwitchGamePlayState(IGamePlayStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
            CurrentStrategy.init(this);
        }
        
        
    }
}