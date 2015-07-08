using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace GraphicalUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ObservableCollection<TurnType> turntypes = new ObservableCollection<TurnType>();

        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;

            Uri imageUrl = new Uri("\\Images\\Pokemon\\001.png", UriKind.Relative);
            RedPokemon.Source = new BitmapImage(imageUrl);
            BluePokemon.Source = new BitmapImage(imageUrl);

            turntypes.Add(new TurnType("Hello World!"));
            Updates.ItemsSource = turntypes;
        }

        int counter;
        private void Attack1_Click(object sender, RoutedEventArgs e) {
            turntypes.Add(new TurnType("item: " + counter));
            counter++;
        }
    }

    public class TurnType : INotifyPropertyChanged {
        private String _description;
        public String Description {
            get { return _description; }
            set { _description = value; }
        }
        public TurnType( String description) {
            _description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
