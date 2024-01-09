using UnityEngine;

namespace Class
{  
    [CreateAssetMenu]
    public class ActorIMG:ScriptableObject
    {
        public Sprite[] BG;
        public Sprite RightActor, WrongActor;
        public Sprite WinnerIMG, LoserIMG;
    }
}