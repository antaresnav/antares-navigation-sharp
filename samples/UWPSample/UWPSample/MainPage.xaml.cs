using Windows.UI.Xaml.Controls;
using AntaresNavigation.Deprecated.Routing.Antares;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Windows.System.Display.DisplayRequest _displayRequest;

        public MainPage()
        {
            this.InitializeComponent();

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                StatusBar.GetForCurrentView().HideAsync();
            }

            _displayRequest = new Windows.System.Display.DisplayRequest();
            _displayRequest.RequestActive();

            AntaresNavigationView.SetRoutingService(new AntaresRoutingService());

            AntaresNavigationView.Map.MapLongClick += (sender, args) =>
            {
                AntaresNavigationView.StartNavigation(args.Point);
                AntaresNavigationView.Map.SetCenterAnchor(0.5f, 0.75f);
            };
        }
    }
}
