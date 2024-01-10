using System.Collections;
using Core;
using Core.SceneSystem;
using Interface;
using UnityEngine;
using UnityEngine.Video;

namespace UI
{
    public class EndupStrategy:IGamePlayStrategy
    {
        private MonoBehaviour mono;
        public void init(GamePlaySystem gamePlaySystem)
        {
            gamePlaySystem._viewManager.SetFeverUIActive(false);
            mono = gamePlaySystem.GetComponent<MonoBehaviour>();
            mono.StartCoroutine(SwitchNext(5, gamePlaySystem));
            switch (GameManager.Instance.CurrentState)
            {
                case MainGameState.Su:
                    playVideoOnFavoraity(gamePlaySystem.SuActorImg.WinnerVid,gamePlaySystem.SuActorImg.LoserVid,gamePlaySystem);
                    break;
                case MainGameState.Fan :
                    playVideoOnFavoraity(gamePlaySystem.FanActorImg.WinnerVid,gamePlaySystem.FanActorImg.LoserVid,gamePlaySystem);
                    break;
            }
            
        }

        void playVideoOnFavoraity(VideoClip winnerClip, VideoClip loserClip,GamePlaySystem gamePlaySystem)
        {
            if (gamePlaySystem.Favoraty > 80)
            {
                gamePlaySystem._VideoManager.playVideo(winnerClip);
            }
            else
            {
                gamePlaySystem._VideoManager.playVideo(loserClip);
            }
        }
        
        IEnumerator SwitchNext(float time,GamePlaySystem gamePlaySystem)
        {
            yield return new WaitForSeconds(time);
            if (GameManager.Instance.CurrentState == MainGameState.Su)
            {
                GameManager.Instance.CurrentState = MainGameState.Fan;
                gamePlaySystem.SwitchGamePlayState(gamePlaySystem.SelectionStrategy);
            }
            else
            {
                GameManager.Instance.SwitchSence(2,MainGameState.Thanks);
            }
        }

        public void update(GamePlaySystem gamePlaySystem)
        {
            throw new System.NotImplementedException();
        }
    }
}