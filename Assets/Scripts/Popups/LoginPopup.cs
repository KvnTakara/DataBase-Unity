using TMPro;
using UnityEngine;

public class LoginPopup : MonoBehaviour
{
    #region Variables

    public TMP_InputField inputNome;

    public GameObject entrarButton;

    #endregion

    #region Funtions

    public async void BotaoEntrar()
    {
        entrarButton.SetActive(false);

        Usuario usuario = await DataManager.BuscaUsuario(inputNome.text);

        if (usuario == null)
        {
            usuario = await DataManager.CriarUsuario(inputNome.text);
        }

        LevelManager.instance.InstantiateCollectables(50);
        LevelManager.instance.CreatePlayer(usuario.id, usuario.pontos);

        Destroy(gameObject);
    }

    #endregion
}
