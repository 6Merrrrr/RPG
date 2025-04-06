using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
     public AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // 如果没有 AudioSource，自动添加一个
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 绑定点击事件
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
