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
        [HideInInspector] public VideoManager _VideoManager;
        [HideInInspector] public AudioManager _AudioManager;
        #endregion

        #region Strategys

        public SelectionStrategy SelectionStrategy = new SelectionStrategy();
        public FeverStartegy FeverStartegy = new FeverStartegy();
        public EndupStrategy EndupStrategy = new EndupStrategy();

        #endregion
        
        private IGamePlayStrategy CurrentStrategy;

        public int Favoraty;
        private void Awake()
        {
            _viewManager = GameObject.Find("Canvas").GetComponent<ViewManager>();
            _dialogManager =  GameObject.Find("Canvas").GetComponent<DialogManager>();
            _selectorManager = GameObject.Find("Canvas").transform.Find("SelecterUI").GetComponent<SelectorManager>();
            _Fevermanager = GameObject.Find("Canvas").transform.Find("FeverTimeUI").GetComponent<FeverManager>();
            _VideoManager = GameObject.Find("Canvas").GetComponent<VideoManager>();
            _AudioManager = GameObject.Find("Audio Source").GetComponent<AudioManager>();
        }

        private void Start()
        {
            SwitchGamePlayState( SelectionStrategy);
        }

        private void Update()
        {
            _viewManager.SetFavorabilityNum(Favoraty);
        }

        public void SwitchGamePlayState(IGamePlayStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
            CurrentStrategy.init(this);
        }
        
        
    }
}