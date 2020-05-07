﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image progressBar;
    public Text progressText;
    public Animator transition;
    public float transitionTime = 1f;

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.fillAmount = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }
    public void LoadLevel (int scenenIndex)
    {
        StartCoroutine(LoadAsynchronously(scenenIndex));
    }
}
