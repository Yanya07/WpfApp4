using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        // Делегат для фильтрации
        public delegate bool FilterDelegate(EventData eventData);

        private List<EventData> events;  // Список данных
        private List<EventData> filteredEvents;  // Отфильтрованный список

        public MainWindow()
        {
            InitializeComponent();
            LoadEvents();  // Загрузка исходных данных
            DisplayEvents(events);  // Отображение всех событий
        }

        private void LoadEvents()// Метод для загрузки событий
        {
            events = new List<EventData>
            {
                new EventData(DateTime.Now.AddDays(-1), "Встреча с Джоном"),
                new EventData(DateTime.Now.AddDays(-5), "Крайний срок проекта"),
                new EventData(DateTime.Now.AddDays(2), "Конференция"),
                new EventData(DateTime.Now, "Код-ревью"),
            };
        }

        private void DisplayEvents(List<EventData> eventList)// Метод для отображения данных в списке
        {
            EventListBox.Items.Clear();
            foreach (var ev in eventList)
            {
                EventListBox.Items.Add(ev);
            }
        }
        private bool FilterByDate(EventData eventData) // Фильтрация по дате (за последние 2 дня)
        {
            return eventData.Date >= DateTime.Now.AddDays(-2);
        }
        private bool FilterByKeyword(EventData eventData) // Фильтрация по ключевому слову "Проект"
        {
            return eventData.Description.IndexOf("Проект", StringComparison.OrdinalIgnoreCase) >= 0;
        }
        private void ApplyFilter(FilterDelegate filter)// Метод для применения фильтра
        {
            filteredEvents = events.FindAll(new Predicate<EventData>(filter));
            DisplayEvents(filteredEvents);
        }
        private void FilterByDateButton_Click(object sender, RoutedEventArgs e) // Обработка выбора фильтра "По дате"
        {
            ApplyFilter(FilterByDate);
        }
        private void FilterByKeywordButton_Click(object sender, RoutedEventArgs e)// Обработка выбора фильтра "По ключевым словам"
        {
            ApplyFilter(FilterByKeyword);
        }
        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)// Сброс фильтров
        {
            DisplayEvents(events);
        }
    }
}
