using Class;
using Tool;
using UnityEngine.SceneManagement;


namespace Core
{
    public enum MainGameState
    {
        WelcomPage,
        Su,
        Fan,
        Thanks
    }
    public class GameManager :StaticSingleton<GameManager>
    {
        public MainGameState CurrentState = MainGameState.WelcomPage;
        private void Awake()
        {
            foreach (var VARIABLE in FindObjectsOfType<GameManager>() )
            {
                if (VARIABLE != this )  Destroy(gameObject);
            }
            
            DontDestroyOnLoad(this);
        }

        public void SwitchSence(int sceneNum,MainGameState nextState)
        {
            SceneManager.LoadScene(sceneNum);
            CurrentState = nextState;
        }

      
    }
}
