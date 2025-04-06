using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manu : MonoBehaviour
{
    // 主界面与设置界面引用
    //[SerializeField] private GameObject Panel;
    [SerializeField] private GameObject OptionPanel;

    // 音量控制组件
    //[SerializeField] private Slider sliderMaster;
    //[SerializeField] private Slider sliderSFX;
    //[SerializeField] private Slider sliderBGM;

    void Start()
    {
        // 绑定按钮事件
        //Button btnStart = GameObject.Find("Begin_Btn").GetComponent<Button>();
        Button btnOptions = GameObject.Find("Option_Btn").GetComponent<Button>();
        Button btnQuit = GameObject.Find("Quit_Btn").GetComponent<Button>();
        Button btnBack = GameObject.Find("Back_Btn").GetComponent<Button>();

        // 初始化界面状态

        //Panel.SetActive(true);
        OptionPanel.SetActive(false);

       
       

        //btnStart.onClick.AddListener(StartGame);
        btnOptions.onClick.AddListener(ShowOptions);
        btnQuit.onClick.AddListener(QuitGame);
        btnBack.onClick.AddListener(BackToMain);

        // 绑定滑动条事件
        //sliderMaster.onValueChanged.AddListener(SetMasterVolume);
        //sliderSFX.onValueChanged.AddListener(SetSFXVolume);
        //sliderBGM.onValueChanged.AddListener(SetBGMVolume);
    }

    // 按钮功能实现
    // private void StartGame()
    // {
    //     SceneManager.LoadScene("Scenes/MainScene"); // 替换为你的首个场景名称
    // }

    private void ShowOptions()
    {
        
        OptionPanel.SetActive(true);
    }

    private void BackToMain()
    {
       
        OptionPanel.SetActive(false);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    // 音量控制逻辑（需根据实际音频管理器扩展）
    //private void SetMasterVolume(float value)
    //{
    //    AudioListener.volume = value;
    //}

    //private void SetSFXVolume(float value)
    //{
    //    // 示例：调用音频管理器中的音效控制
    //    // AudioManager.Instance.SetSFXVolume(value);
    //}

    //private void SetBGMVolume(float value)
    //{
    //    // 示例：调用音频管理器中的背景音乐控制
    //    // AudioManager.Instance.SetBGMVolume(value);
    //}
}

