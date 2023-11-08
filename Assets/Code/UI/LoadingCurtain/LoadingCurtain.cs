using System;
using System.Collections;
using UnityEngine;

namespace Code.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            while (canvasGroup.alpha >= 0.03f)
            {
                yield return new WaitForSeconds(0.1f);
                canvasGroup.alpha -= 0.1f;
            }

            gameObject.SetActive(false);
        }
    }
}