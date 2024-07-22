using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.Droid
{
    public class FileAccessHelper // Criado uma classe para ajudar a executar o BD
    {
        public static string GetFolderPath(string fileName) // Criado um método para pegar o caminho do BD
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // variável do tipo string, onde a mesma é  atribuído um método onde irá salver o BD na pasta Personal
            return System.IO.Path.Combine(path, fileName); //retorna a combinação do caminho do banco com o nome do mesmo
        }
    }
}