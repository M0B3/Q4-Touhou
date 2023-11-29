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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
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
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void LoadSceneTwo()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void LoadSceneThree()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    public void LoadSceneFour()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
