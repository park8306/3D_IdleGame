using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageFailUI : MonoBehaviour
{
    [SerializeField] private Button okBtn;

    private void Start()
    {
        okBtn.onClick.AddListener(OkBtn);
    }
    private void OkBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
