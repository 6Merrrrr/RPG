using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    
   public GameObject loadScreen;
   public Slider slider;
   public Text text;
   public void LoadNextLevel()
   {
         StartCoroutine(LoadLevel());
   }
    IEnumerator LoadLevel()
    {
         loadScreen.SetActive(true);

         AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
         operation.allowSceneActivation = false;
         while (!operation.isDone)
         {
              float progress = Mathf.Clamp01(operation.progress / 0.9f);
              slider.value = progress;
              text.text = progress * 100f + "%";
              if (operation.progress >= 0.9f)
            {
                // 模拟延迟（可选）
                slider.value=1;
                text.text = "Press Anykey to continue";
                
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

              yield return null;
         }
    }

}
