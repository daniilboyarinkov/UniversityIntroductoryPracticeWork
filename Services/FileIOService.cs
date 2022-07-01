using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using TodoApp.Models;

namespace TodoApp.Services
{
    internal class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path) => PATH = path;
        public ObservableCollection<TodoModel> LoadData()
        {
            bool fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<TodoModel>();
            }
            using StreamReader reader = File.OpenText(PATH);
            string? fileText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<ObservableCollection<TodoModel>>(fileText)
                ?? new ObservableCollection<TodoModel>();
        }

        async public void SaveData(ObservableCollection<TodoModel> todos)
        {
            using StreamWriter writer = File.CreateText(PATH);
            string output = JsonConvert.SerializeObject(todos);
            await writer.WriteAsync(output);
        }
    }
}
