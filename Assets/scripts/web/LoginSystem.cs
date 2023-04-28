using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginSystem : MonoBehaviour
{
    public enum CurrentWindow { Login, Register }
    public CurrentWindow currentWindow = CurrentWindow.Login;

    string loginUsername = "";
    string loginPassword = "";

    string registerUsername = "";
    string registerFullName = "";
    string registerEmail = "";
    string registerPassword = "";
    string errorMessage = "";

    bool isWorking = false;
    bool registrationCompleted = false;
    bool isLoggedIn = false;

    //Logged-in user data
    string userName = "";
    string userEmail = "";

    string rootURL = "http://localhost/redstorge/"; //Path where php files are located

    void OnGUI()
    {
        if (!isLoggedIn)
        {
            if (currentWindow == CurrentWindow.Login)
            {
                GUI.Window(0, new Rect(Screen.width - (Screen.width / 3 - 25), Screen.height / 2 - 115, 250, 230), LoginWindow, "Iniciar Sesión");
            }
            if (currentWindow == CurrentWindow.Register)
            {
                GUI.Window(0, new Rect(Screen.width - (Screen.width / 3 - 25), Screen.height / 2 - 165, 250, 330), RegisterWindow, "Registrarse");
            }
        }

        GUI.Label(new Rect(5, 5, 500, 25), "Status: " + (isLoggedIn ? "Logged-in Username: " + userName + " Email: " + userEmail : "Logged-out"));
        if (isLoggedIn)
        {
            if (GUI.Button(new Rect(5, 30, 100, 25), "Log Out"))
            {
                isLoggedIn = false;
                userName = "";
                userEmail = "";
                currentWindow = CurrentWindow.Login;
            }
        }
    }

    void LoginWindow(int index)
    {
        if (isWorking)
        {
            GUI.enabled = false;
        }

        if (errorMessage != "")
        {
            GUI.color = Color.red;
            GUILayout.Label(errorMessage);
        }
        if (registrationCompleted)
        {
            GUI.color = Color.green;
            GUILayout.Label("Registrado Correctamente!");
        }

        GUI.color = Color.white;
        GUILayout.Label("Nombre de Usuario:");
        loginUsername = GUILayout.TextField(loginUsername);
        GUILayout.Label("Password:");
        loginPassword = GUILayout.PasswordField(loginPassword, '*');

        GUILayout.Space(5);

        if (GUILayout.Button("Submit", GUILayout.Width(85)))
        {
            StartCoroutine(LoginEnumerator());
        }

        GUILayout.FlexibleSpace();

        GUILayout.Label("Do not have account?");
        if (GUILayout.Button("Register", GUILayout.Width(125)))
        {
            ResetValues();
            currentWindow = CurrentWindow.Register;
        }
    }

    void RegisterWindow(int index)
    {
        if (isWorking)
        {
            GUI.enabled = false;
        }

        if (errorMessage != "")
        {
            GUI.color = Color.red;
            GUILayout.Label(errorMessage);
        }

        GUI.color = Color.white;
        GUILayout.Label("Nombre de Usuario:");
        registerUsername = GUILayout.TextField(registerUsername, 50);
        GUILayout.Label("Nombre Completo:");
        registerFullName = GUILayout.TextField(registerFullName, 100);
        GUILayout.Label("Email:");
        registerEmail = GUILayout.TextField(registerEmail, 50);
        GUILayout.Label("Contraseña:");
        registerPassword = GUILayout.PasswordField(registerPassword, '*', 50);

        GUILayout.Space(5);

        if (GUILayout.Button("Submit", GUILayout.Width(85)))
        {
            StartCoroutine(RegisterEnumerator());
        }

        GUILayout.FlexibleSpace();

        GUILayout.Label("Already have an account?");
        if (GUILayout.Button("Login", GUILayout.Width(125)))
        {
            ResetValues();
            currentWindow = CurrentWindow.Login;
        }
    }

    IEnumerator RegisterEnumerator()
    {
        isWorking = true;
        registrationCompleted = false;
        errorMessage = "";

        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", registerUsername);
        form.AddField("nombre_completo", registerFullName);
        form.AddField("email", registerEmail);
        form.AddField("password", registerPassword);
        form.AddField("tipo_usuario", "a");

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "reg_usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                errorMessage = www.error;
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
                {
                    ResetValues();
                    registrationCompleted = true;
                    currentWindow = CurrentWindow.Login;
                }
                else
                {
                    errorMessage = responseText;
                }
            }
        }

        isWorking = false;
    }

    IEnumerator LoginEnumerator()
    {
        isWorking = true;
        registrationCompleted = false;
        errorMessage = "";

        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", loginUsername);
        form.AddField("password", loginPassword);

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                errorMessage = www.error;
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
                {
                    string[] dataChunks = responseText.Split('|');
                    userName = dataChunks[1];
                    userEmail = dataChunks[2];

                    StateNameController.nombre_usuario = userName;
                    StateNameController.pregunta = 1;
                    LoadScene("colision");
                }
                else
                {
                    errorMessage = responseText;
                }
            }
        }

        isWorking = false;
    }

    void ResetValues()
    {
        errorMessage = "";
        loginUsername = "";
        loginPassword = "";
        registerUsername = "";
        registerFullName = "";
        registerEmail = "";
        registerPassword = "";
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}