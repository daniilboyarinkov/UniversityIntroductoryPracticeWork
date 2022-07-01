using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.BLogic.Extensions;
using System.Collections.Generic;

namespace TodoApp.BLogic
{
    internal class Logic : INotifyPropertyChanged
    {
        private readonly static string PATH = $"{Environment.CurrentDirectory}\\TodoDataList.json";
        private readonly FileIOService? _fileIOService = new(PATH);
        private List<StatusModel> _statuses = new() { ReadyStatus, ProgressedStatus, StoppedStatus };
        // Should be in another logical group I guess but for now it's acceptable
        private readonly static StatusModel ReadyStatus = new("Создано", "Выберите статус:");
        private readonly static StatusModel ProgressedStatus = new("Выполняется", "Выполняется");
        private readonly static StatusModel StoppedStatus = new("Приостановлено", "Приостановлено");
        private readonly static StatusModel FinishedStatus = new("Завершено", "Завершено");
        // This should also be somewhere else but u know... XD
        private readonly static CategoryModel Default = new("Secondary", "Категория:");
        private readonly static CategoryModel Education = new("Education", "Учеба");
        private readonly static CategoryModel HouseWork = new("HouseWork", "Домашние дела");
        private readonly static CategoryModel Important = new("Important", "Срочно");
        private readonly static CategoryModel Secondary = new("Secondary", "Второстепенно");
        private readonly static CategoryModel SelfDevelopment = new("SelfDevelopment", "Саморазвитие");
        private readonly static CategoryModel Work = new("Work", "Работа");
        
        private RelayCommand? _deleteTodo;
        private RelayCommand? _addTodo;
        private RelayCommand? _completeTodo;
        private RelayCommand? _loadTodoData;
        private RelayCommand? _saveTodoData;
        private RelayCommand? _handleStatuses;

        public ObservableCollection<TodoModel> Todos { get; set; } = new();
        public TodoModel? SelectedTodo { get; set; }
        public TodoModel NewTodo { get; set; } = new() { Deadline=DateTime.Today };
        public List<CategoryModel> Categories { get; set; } = new() { Default, Education, HouseWork, Important, Secondary, SelfDevelopment, Work };
        public List<StatusModel> Statuses
        {
            get => _statuses;
            set { _statuses = value; NotifyPropertyChanged("Statuses"); }
        }

        public RelayCommand LoadTodoData => _loadTodoData ??= new RelayCommand(() =>
        {
            try
            {
                if (_fileIOService is null) return;
                _fileIOService.LoadData().ForEach(todo => Todos.Add(todo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс... Ошибка чтения файла...");
                Environment.Exit(1);
            }
        });
        public RelayCommand SaveTodoData => _saveTodoData ??= new RelayCommand(() =>
        {
            try
            {
                if (_fileIOService is null) return;
                _fileIOService.SaveData(Todos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс... Ошибка чтения файла...");
                Environment.Exit(1);
            }
        });
        public RelayCommand CompleteTodo => _completeTodo ??= new RelayCommand(() =>
        {
            if (SelectedTodo is null) return;
            if (SelectedTodo.Status == "Завершено")
                SelectedTodo.СompletionDate = DateTime.Now;
        });
        public RelayCommand HandleStatuses => _handleStatuses ??= new RelayCommand(() =>
        {
            if (SelectedTodo is null) return;
            if (SelectedTodo.Status == "Создано")
                Statuses = new() { ReadyStatus, ProgressedStatus, StoppedStatus };
            else if (SelectedTodo.Status == "Выполняется" || SelectedTodo.Status == "Приостановлено")
                Statuses = new() { ProgressedStatus, StoppedStatus, FinishedStatus };
            else if (SelectedTodo.Status == "Завершено")
                Statuses = new() { FinishedStatus };
            else
                Statuses = new() { ProgressedStatus, StoppedStatus };
        });
        public RelayCommand DeleteTodo => _deleteTodo ??= new RelayCommand(() =>
        {
            if (SelectedTodo is null)
            {
                MessageBox.Show("Вы не выбрали задачу из списка...", "Выберите Задачу из списка");
                return;
            }
            Todos.Remove(SelectedTodo);
        });
        public RelayCommand AddTodo => _addTodo ??= new RelayCommand(() =>
        {
            if (NewTodo.Content == string.Empty)
            {
                MessageBox.Show("Поле 'Задача' не может быть пустым", "Заполните поле 'Задача'");
                return;
            }

            NewTodo.Category = ConvertCategoryFromRussian(NewTodo.Category.ToString());
            Todos.Add(new TodoModel() {
                Deadline = NewTodo.Deadline, 
                Category = NewTodo.Category, 
                Content = NewTodo.Content, 
                Status = "Создано" 
            });
        });


        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        // ------------------------------------------------------------------
        // Helpers (should be in separeted block but for now it's ok I guess)
        // ------------------------------------------------------------------
        static string ConvertCategoryFromRussian(string inp) => inp
                .Replace("System.Windows.Controls.ComboBoxItem: ", "") switch
        {
            "Срочно" => "Important",
            "Important" => "Important",
            "Работа" => "Work",
            "Work" => "Work",
            "Учеба" => "Education",
            "Education" => "Education",
            "Саморазвитие" => "SelfDevelopment",
            "SelfDevelopment" => "SelfDevelopment",
            "Домашние дела" => "HouseWork",
            "HouseWork" => "HouseWork",
            "Второстепенно" => "Secondary",
            "Secondary" => "Secondary",
            _ => "Secondary",
        };
    }
}
