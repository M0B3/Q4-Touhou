using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _selectionMenu;
    [SerializeField] private bool _isMainMenu;

    private bool _isActive = false;

    private void Start()
    {
        if (_isMainMenu)
            _selectionMenu.SetActive(false);
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void SelectionLevelButton()
    {
        if (!_isActive)
        {
            _selectionMenu.SetActive(true);
            _animator.SetTrigger("Open");
            _isActive = true;
        }
    }
    public void BackButton()
    {
        if (_isActive)
        {
            _selectionMenu.SetActive(false);
            _animator.SetTrigger("Close");
            _isActive = false; 
        }
    }

    public void LoadSceneOne()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void LoadSceneTwo()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }
    public void LoadSceneThree()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(3);
    }
    public void LoadSceneFour()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(4);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
