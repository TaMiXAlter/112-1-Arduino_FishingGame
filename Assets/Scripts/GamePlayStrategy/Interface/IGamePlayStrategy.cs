using Core.SceneSystem;

namespace Interface
{
    public interface IGamePlayStrategy
    {
       abstract void init(GamePlaySystem gamePlaySystem);
       abstract void update(GamePlaySystem gamePlaySystem);
    }
}