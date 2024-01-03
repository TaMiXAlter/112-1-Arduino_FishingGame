using Core;
using UnityEngine;

namespace InterFaces
{
    public interface IGamePlayStrategy
    {
        void Init(GameManager _gameManager);
        void Update(GameManager _gameManager);
        void EndUp(GameManager _gameManager);
    }
}