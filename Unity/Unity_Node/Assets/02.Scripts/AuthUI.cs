using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;

    public Button registerButton;
    public Button loginButton;
    public Button logoutButton;
    public Button getDatabutton;

    public Text statusText;

    private AuthManager authManager;

    // Start is called before the first frame update
    void Start()
    {
        authManager = GetComponent<AuthManager>();
        registerButton.onClick.AddListener(OnRegisterClick);
        loginButton.onClick.AddListener(OnLoginClick);
        loginButton.onClick.AddListener(OnLogoutClick);
        loginButton.onClick.AddListener(OnGetDataClick);

    }

    private void OnLoginClick()
    {
        StartCoroutine(LoginCoroutine());
    }

    private IEnumerator LoginCoroutine()
    {
        statusText.text = "�α��� ��...";
        yield return StartCoroutine(authManager.Login(usernameInput.text, passwordInput.text));
        statusText.text = "�α��� ����"; 
    }

    private void OnRegisterClick()
    {
        StartCoroutine(RegisterCoroutine());
    }
    

    private IEnumerator RegisterCoroutine()
    {
        statusText.text = "ȸ������ ��...";
        yield return StartCoroutine(authManager.Register(usernameInput.text, passwordInput.text));
        statusText.text = "ȸ������ ����. �α��� ���ּ���.";
    }

    private void OnLogoutClick()
    {
        StartCoroutine(RegisterCoroutine());
    }
    private IEnumerator LogoutCoroutine()
    {
        statusText.text = "�α׾ƿ� ��...";
        yield return StartCoroutine(authManager.Logout());
        statusText.text = "�α׾ƿ� ����";
    }

    private void OnGetDataClick()
    {
        StartCoroutine(GetDataCoroutine());
    }
    private IEnumerator GetDataCoroutine()
    {
        statusText.text = "������ ��û ��";
        yield return StartCoroutine(authManager.GetProtectedData());
        statusText.text = "������ ��û �Ϸ�";
    }
}
