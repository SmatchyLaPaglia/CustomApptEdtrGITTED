using Xamarin.Forms;

namespace AdditionalAttribute
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AdditionalAttributePage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
