using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject GamePanel;

    public MainCamera camera;
    //  public GameObject MenuPanel;
    // public LevelLoaderController levelLoaderController;


    private void Awake()
    {
        //  levelLoaderController.gameObject.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
        //      MenuCanvas.enabled = true;
        //    GameCanvas.enabled = false;
        MenuPanel.SetActive(true);
        GamePanel.SetActive(false);
        //   levelLoaderController.enabled = true;
        // MenuCanvas.gameObject.SetActive(true);
        //   GameCanvas.gameObject.SetActive(false);
        //   levelLoaderController.gameObject.SetActive(true);


    }

    public virtual void StartGame()
    {
        //    MenuCanvas.enabled = false;
        //  GameCanvas.enabled = true;



        LeanTween.alphaCanvas(MenuPanel.GetComponent<CanvasGroup>(), 0, 1f);
        // LeanTween.moveLocalY(MenuPanel.gameObject, 300f, 2f);
        //    LeanTween.sequence().append(1f);
        StartCoroutine(WaitCoroutine(1f));
        // GameCanvas.gameObject.SetActive(true);
        GamePanel.SetActive(true);
        //   LeanTween.alphaCanvas(GameCanvas.GetComponent<CanvasGroup>(), 0, 1f);
        //   GameCanvas.enabled = true;
        GamePanel.GetComponent<CanvasGroup>().alpha = 0f;
        LeanTween.alphaCanvas(GamePanel.GetComponent<CanvasGroup>(), 1f, 2f);
        //  StartCoroutine(WaitCoroutine(1f));
        camera.switchCameraAngels();       
        camera.IsGameStarted = true;

    }

    public void ExitGame()
    {
        Application.Quit();
        //  levelLoaderController.LoadScene(0);
    }

    IEnumerator OnlyWaitCoroutine(float time)
    {

        yield return new WaitForSeconds(time);
    }

    protected IEnumerator WaitCoroutine(float time)
    {

        yield return new WaitForSeconds(time);
        MenuPanel.SetActive(false);
        //    GamePanel.SetActive(true);
        //  MenuCanvas.gameObject.SetActive(false);
        // GameCanvas.gameObject.SetActive(true);
        // MenuCanvas.GetComponent<CanvasGroup>().interactable = false;
        //  MenuCanvas.enabled = true ;
        //   GameCanvas.GetComponent<CanvasGroup>().interactable = true;

        //  Debug.Log("done");
        //   GameCanvas.enabled = true;
        //   GameCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }

}
