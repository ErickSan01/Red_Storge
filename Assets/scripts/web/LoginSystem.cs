using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que maneja el sistema de inicio de sesión y registro de usuarios.
/// </summary>
public class LoginSystem : MonoBehaviour
{
    /// <summary>
    /// Enumeración que representa la ventana actual del sistema.
    /// </summary>
    public enum CurrentWindow { Login, Register }

    /// <summary>
    /// Ventana actual del sistema.
    /// </summary>
    public CurrentWindow currentWindow = CurrentWindow.Login;

    // Variables de inicio de sesión
    string loginUsername = "";
    string loginPassword = "";

    // Variables de registro
    string registerUsername = "";
    string registerFullName = "";
    string registerEmail = "";
    string registerPassword = "";
    string errorMessage = "";

    // Variables de estado
    bool isWorking = false;
    bool registrationCompleted = false;
    bool isLoggedIn = false;

    // Datos del usuario logueado
    string userName = "";
    string userEmail = "";

    // URL base para las solicitudes HTTP
    string rootURL = "http://localhost/"; // Ruta donde se encuentran los archivos PHP

    /// <summary>
    /// Método que se ejecuta en cada frame para dibujar la interfaz de usuario.
    /// </summary>
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

        GUI.Label(new Rect(5, 5, 500, 25), "Estado: " + (isLoggedIn ? "Usuario logueado: " + userName + " Email: " + userEmail : "Usuario no logueado"));
        if (isLoggedIn)
        {
            if (GUI.Button(new Rect(5, 30, 100, 25), "Cerrar Sesión"))
            {
                isLoggedIn = false;
                userName = "";
                userEmail = "";
                currentWindow = CurrentWindow.Login;
            }
        }
    }

    /// <summary>
    /// Método que dibuja la ventana de inicio de sesión.
    /// </summary>
    /// <param name="index">Índice de la ventana.</param>
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
            GUILayout.Label("¡Registro completado correctamente!");
        }

        GUI.color = Color.white;
        GUILayout.Label("Nombre de Usuario:");
        loginUsername = GUILayout.TextField(loginUsername);
        GUILayout.Label("Contraseña:");
        loginPassword = GUILayout.PasswordField(loginPassword, '*');

        GUILayout.Space(5);

        if (GUILayout.Button("Enviar", GUILayout.Width(85)))
        {
            StartCoroutine(LoginEnumerator());
        }

        GUILayout.FlexibleSpace();

        GUILayout.Label("¿No tienes cuenta?");
        if (GUILayout.Button("Registrarse", GUILayout.Width(125)))
        {
            ResetValues();
            currentWindow = CurrentWindow.Register;
        }
    }

    /// <summary>
    /// Método que dibuja la ventana de registro.
    /// </summary>
    /// <param name="index">Índice de la ventana.</param>
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

        if (GUILayout.Button("Enviar", GUILayout.Width(85)))
        {
            StartCoroutine(RegisterEnumerator());
        }

        GUILayout.FlexibleSpace();

        GUILayout.Label("¿Ya tienes una cuenta?");
        if (GUILayout.Button("Iniciar Sesión", GUILayout.Width(125)))
        {
            ResetValues();
            currentWindow = CurrentWindow.Login;
        }
    }

    /// <summary>
    /// Corrutina para realizar el registro de un usuario.
    /// </summary>
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

    /// <summary>
    /// Corrutina para realizar el inicio de sesión de un usuario.
    /// </summary>
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
                    LoadScene("nivel1");
                }
                else
                {
                    errorMessage = responseText;
                }
            }
        }

        isWorking = false;
    }

    /// <summary>
    /// Método para restablecer los valores de las variables.
    /// </summary>
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

    /// <summary>
    /// Método para cargar una escena.
    /// </summary>
    /// <param name="sceneName">Nombre de la escena a cargar.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}