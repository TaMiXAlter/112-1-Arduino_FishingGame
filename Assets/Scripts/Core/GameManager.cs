using Core.Assest;
using GamePlayStrategys;
using InterFaces;
using JetBrains.Annotations;
using Tool;
using UnityEngine;


namespace Core
{
    public class GameManager :Singleton<GameManager>
    {
        private IGamePlayStrategy _curentStrategy;
        public MainPageStrategy _mainPageStrategy = new MainPageStrategy();
        public SelectionStrategy _selectionStrategy = new SelectionStrategy();
        
        public TextSorter _textSorter = new TextSorter();
        public TextReader _textReader = new TextReader();
        private void Awake()
        {
            foreach (var VARIABLE in FindObjectsOfType<GameManager>() )
            {
                if (VARIABLE != this )  Destroy(gameObject);
            }

            DontDestroyOnLoad(this);
            _curentStrategy = _mainPageStrategy;
            _curentStrategy.Init(this);
        }
        
        private void Update()
        {
            _curentStrategy.Update(this);
        }

        public void SwitchStrategy(IGamePlayStrategy iGamePlayStrategy)
        {
            _curentStrategy.EndUp(this);
            _curentStrategy = iGamePlayStrategy;
            _curentStrategy.Init(this);
        }

      
    }
}
