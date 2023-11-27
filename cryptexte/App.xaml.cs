using cryptexte.Vues;

namespace cryptexte
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CryptPage();
        }
    }
}
