using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEditor.PackageManager.Requests;

public class Usuario
{
    public int id;
    public string name;
    public int pontos;
    public string created_at;
}

public class NewUsuario
{
    public string name;
}

public class DataManager : MonoBehaviour
{
    #region Variables

    static string apiUrl = "https://wuelwbydckxxzznxcuto.supabase.co/rest/v1/usuarios";
    static string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Ind1ZWx3YnlkY2t4eHp6bnhjdXRvIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTIzNDcwMTAsImV4cCI6MjAyNzkyMzAxMH0.jOReH6UuETVN_AbZnFXHeSG3BMHB1PXk5iXWkTUcn9o";

    #endregion

    /// <summary>
    /// Buscar o usuario pelo nome
    /// </summary>
    public static async Task<Usuario> BuscaUsuario(string _name)
    {
        string requestUrl = $"{apiUrl}?name=eq.{_name}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

        string response = request.downloadHandler.text;

        if ( response == "[]")
        {
            return null;
        }

        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
        Debug.Log($"ID: {usuarios[0].id} | User: {usuarios[0].name}");

        return usuarios[0];
    }

    /// <summary>
    /// Criar novo Usuario
    /// </summary>
    public static async Task<Usuario> CriarUsuario (string _name)
    {
        string requestUrl = $"{apiUrl}?apikey={apiKey}";

        string json = $" \"name\" : \"{_name}\" , \"pontos\" : {0} ";
        json = "{" + json + "}" ;

        UnityWebRequest request = UnityWebRequest.Post(requestUrl, json, "application/json");
        await request.SendWebRequest();

        return await BuscaUsuario(_name);
    }

    /// <summary>
    /// Atualiza pontos buscando pelo nome do usuario.
    /// </summary>
    public static async void AlterarPontos(int _id, int _pontos)
    {
        string json = "{ \"pontos\": " + _pontos + " }";

        string url = $"{apiUrl}?id=eq.{_id}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Put(url, json);
        request.method = "PATCH";
        request.SetRequestHeader("Content-Type", "application/json");

        await request.SendWebRequest();

        Debug.Log($"Pontos alterados: Id={_id}, Pontos={_pontos}");
    }

    /// <summary>
    /// Busca todos os usuarios e os adiciona em uma lista.
    /// </summary>
    public static async void RankingUsuarios()
    {
        Debug.Log("GerandoRankingUsuarios");

        string requestUrl = $"{apiUrl}?apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

        string response = request.downloadHandler.text;

        if (response == "[]")
        {
            Debug.Log($"null request: {requestUrl}");
        }

        LevelManager.instance.rankingList = JsonConvert.DeserializeObject<List<Usuario>>(response);
    }
}
