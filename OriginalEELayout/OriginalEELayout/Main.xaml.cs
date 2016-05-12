using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OriginalEELayout
{
    public partial class Main : ContentPage
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public Main()
        {
            InitializeComponent();
            EmployeeView.ItemsSource = employees;

            EmployeeView.ItemSelected += EmployeeView_ItemSelected;
            EmployeeView.RefreshCommand = new Command(() =>
            {
                EmployeeView.IsRefreshing = true;

                for (int i = 0; i < 1000000; i++)
                {

                }

                EmployeeView.IsRefreshing = false;
            });

            employees.Add(new Employee { DisplayName = "Rob Finnerty", Image= "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Bill Wrestler", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Dr. Geri-Beth Hooper", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Dr. Keith Joyce-Purdy", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Sheri Spruce", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Burt Indybrick", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Dr. Keith Joyce-Purdy", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Sheri Spruce", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });
            employees.Add(new Employee { DisplayName = "Burt Indybrick", Image = "http://static.c-span.org/assets/images/series/americanPresidents/43_400.png", Detail = "A bit of detail for fun" });

        }

        void EmployeeView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", ((Employee)e.SelectedItem).DisplayName, "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }

    public class Employee
    {
        public string DisplayName { get; set; }
        public string Image { get; set; }

        public string Detail { get; set; }
    }

    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            //instantiate each of our views
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "title");
            right.SetBinding(Label.TextProperty, "subtitle");
            image.SetBinding(Image.SourceProperty, "image");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}
