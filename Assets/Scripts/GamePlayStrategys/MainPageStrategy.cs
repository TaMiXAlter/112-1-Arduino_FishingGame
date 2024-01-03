using Core;
using InterFaces;
using UnityEngine.SceneManagement;

namespace GamePlayStrategys
{
    public class MainPageStrategy:IGamePlayStrategy
    {
        private const string nextScenceName = "Fishing";
        public void Init(GameManager _gameManager)
        {
            InputSystem.Instance.RButtonPress += () => _gameManager.SwitchStrategy(_gameManager._selectionStrategy);
            InputSystem.Instance.LButtonPress += () => _gameManager.SwitchStrategy(_gameManager._selectionStrategy);
        }

        public void Update(GameManager _gameManager)
        {
            
        }

        public void EndUp(GameManager _gameManager)
        {
            InputSystem.Instance.Intialize();
            SceneManager.LoadScene(nextScenceName);
        }
    }
}