using UnityEngine;
using UnityEngine.Video;

namespace Class
{  
    [CreateAssetMenu]
    public class ActorIMG:ScriptableObject
    {
        public Sprite[] BG;
        public Sprite RightActor, WrongActor;
        public VideoClip WinnerVid, LoserVid;
    }
}