using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiCtrl : MonoBehaviour
{
    ///<summary>
    ///페이드인(서서히 나타나는 애니메이션)
    ///</summary>
    public GameObject[] FadeObject;
    ///<summary>
    ///페이드인 완료 후 활성화하고 싶은 버튼
    ///</summary>
    public GameObject[] ActiveObjects;
    ///<summary>
    ///Ui 비행기
    ///</summary>
    public Transform objPlayer;
    ///<summary>
    ///Ui 랭크
    ///</summary>
    public GameObject RankOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveRoutain(new Vector2(0, Screen.height / 2), 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnStart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    public void BtnRank()
    {

    }

    IEnumerator FadeIn()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * 0.5f;
            foreach(GameObject obj in FadeObject)
            {
                Color imgColor = obj.GetComponent<Image>().color;
                imgColor.a = time;
                obj.GetComponent<Image>().color = imgColor;
                yield return null;
            }
        }
        foreach (GameObject obj in ActiveObjects)
        {
            obj.SetActive(true);
        }
    }

    IEnumerator MoveRoutain(Vector2 destination, float time)
    {
        Vector2 startPos = objPlayer.GetComponent<RectTransform>().anchoredPosition;
        float dtime = 0f;
        while (dtime < time)
        {
            dtime += Time.deltaTime;
            float t = dtime / time;
            objPlayer.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPos, destination, t);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeIn());
    }
}
