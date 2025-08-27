using Telerik.Maui.Handlers;

namespace GoalsGalore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if ANDROID
            //Bug fix for Android 8.1 with Telerik MAUI 9.0.0
            RadTextInputHandler.TextInputMapper.ModifyMapping("CustomCursorColor", (h, v, m) => { });
#endif

            SetupDefaultPreferences();
        }

        public static void SetupDefaultPreferences()
        {
            if (Current != null)
            {
                var theme = Preferences.Default.Get("theme", 1);
                //theme = 1;
                switch (theme)
                {
                    case 1:
                        Current.UserAppTheme = AppTheme.Light;
                        break;

                    case 2:
                        Current.UserAppTheme = AppTheme.Dark;
                        break;
                }
            }
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = new(new AppShell());

#if WINDOWS
            window.Activated += Window_Activated;
#endif

            return window;
        }

#if WINDOWS
        private static async void Window_Activated(object sender, EventArgs e)
        {
            const int defaultWidth = 480;
            const int defaultHeight = 725;

            // change window size.
            if (sender is Window window)
            {
                window.Width = defaultWidth;
                window.Height = defaultHeight;

                // give it some time to complete window resizing task.
                await window.Dispatcher.DispatchAsync(() => { });

                var disp = DeviceDisplay.Current.MainDisplayInfo;

                // move to screen center
                window.X = (disp.Width / disp.Density - window.Width) / 2 + 400;
                window.Y = (disp.Height / disp.Density - window.Height) / 2;

                window.Activated -= Window_Activated;
            }
        }
#endif
    }
}