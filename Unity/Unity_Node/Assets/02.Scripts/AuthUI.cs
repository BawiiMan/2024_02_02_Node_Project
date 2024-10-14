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
        statusText.text = "로그인 중...";
        yield return StartCoroutine(authManager.Login(usernameInput.text, passwordInput.text));
        statusText.text = "로그인 성공"; 
    }

    private void OnRegisterClick()
    {
        StartCoroutine(RegisterCoroutine());
    }
    

    private IEnumerator RegisterCoroutine()
    {
        statusText.text = "회원가입 중...";
        yield return StartCoroutine(authManager.Register(usernameInput.text, passwordInput.text));
        statusText.text = "회원가입 성공. 로그인 해주세요.";
    }

    private void OnLogoutClick()
    {
        StartCoroutine(RegisterCoroutine());
    }
    private IEnumerator LogoutCoroutine()
    {
        statusText.text = "로그아웃 중...";
        yield return StartCoroutine(authManager.Logout());
        statusText.text = "로그아웃 성공";
    }

    private void OnGetDataClick()
    {
        StartCoroutine(GetDataCoroutine());
    }
    private IEnumerator GetDataCoroutine()
    {
        statusText.text = "데이터 요청 중";
        yield return StartCoroutine(authManager.GetProtectedData());
        statusText.text = "데이터 요청 완료";
    }
}
