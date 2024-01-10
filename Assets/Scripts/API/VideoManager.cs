
using System;
using System.Collections;
using Core.SceneSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private GameObject videoGameObject;
    private VideoPlayer _videoPlayer;

    private void Awake()
    {
        videoGameObject = GameObject.Find("Video Player").GameObject();
        _videoPlayer = videoGameObject.GetComponent<VideoPlayer>();
        
        videoGameObject.SetActive(false);
    }

    public void playVideo(VideoClip clip)
    {
        videoGameObject.SetActive(true);
        _videoPlayer.clip = clip;
        _videoPlayer.Play();
        StartCoroutine(HideWhenEnd(5));
    }

    IEnumerator HideWhenEnd(float time)
    {
        yield return new WaitForSeconds(time);
        videoGameObject.SetActive(false);
    }
}
