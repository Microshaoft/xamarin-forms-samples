using System;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class CustomPositionBarPage : ContentPage
    {
        bool polling = true;

        public CustomPositionBarPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    positionLabel.Text = mediaElement.Position.ToString("mm\\:ss\\.ff");
                });
                return polling;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            polling = false;
        }

        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {
            if (mediaElement.CurrentState == MediaElementState.Closed ||
                mediaElement.CurrentState == MediaElementState.Stopped ||
                mediaElement.CurrentState == MediaElementState.Paused)
            {
                mediaElement.Play();
            }
            else if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
        }

        void OnStopButtonClicked(object sender, EventArgs args)
        {
            mediaElement.Stop();
        }
    }
}
