using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
   public AudioSource backgroundMusic; // 拖入 AudioSource 组件
   //public AudioSource soundEffect;     // 拖入 AudioSource 组件
    public Slider volumeSlider;         // 拖入 Slider 组件
    //public Slider soundEffectSlider;    // 拖入 Slider 组件

    void Start()
    {
        // 初始化滑动条的值
        //volumeSlider.value = backgroundMusic.volume;

        // 绑定滑动条事件
        volumeSlider.onValueChanged.AddListener(SetVolume);
        //soundEffectSlider.onValueChanged.AddListener(SetSoundEffectVolume);

    }

    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    
    }
    // public void SetSoundEffectVolume(float volume)
    // {
    //     soundEffect.volume = volume;
    // }
}
