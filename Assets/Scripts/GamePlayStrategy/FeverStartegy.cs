using Core.SceneSystem;
using Interface;
using UnityEngine;

namespace GamePlayStrategy
{
    public class FeverStartegy:MonoBehaviour,IGamePlayStrategy
    {
        public void init(GamePlaySystem gamePlaySystem)
        {
            Debug.Log("FEVER");
            
        }

        public void update(GamePlaySystem gamePlaySystem)
        {

        }
    }
}