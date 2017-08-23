using System.Threading.Tasks;
using VacationSpots.ViewModels;
using Xamarin.Forms;

namespace MobileVacationSpots
{
    public partial class MainPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            InitializeComponent();
        }

        private async void OnExpandFrame(object sender, System.EventArgs e)
        {
            const int animationTime = 250;

            var owner = (Grid) sender;
            var arrow = owner.FindByName<Label>(nameof(ExpandArrow));
            var description = owner.FindByName<ScrollView>(nameof(DescriptionText));
            double maxHeight = VacationCarousel.Height / 2 - 50 - owner.Height; 

            if (!description.IsVisible)
            {
                description.IsVisible = true;
                description.Animate("showText", val => description.HeightRequest = val, 
                    0, maxHeight, 20, animationTime, Easing.Linear);
                var t1 = description.FadeTo(1, animationTime);
                var t2 = arrow.RotateXTo(180, animationTime);
                await Task.WhenAll(t1, t2).ConfigureAwait(false);
            }
            else
            {
                description.Animate("hideText", val => description.HeightRequest = val,
                    description.Height, 0, 20, animationTime, Easing.Linear);
                var t1 = description.FadeTo(1, animationTime);
                var t2 = arrow.RotateXTo(0, animationTime);
                await Task.WhenAll(t1, t2);
                description.IsVisible = false;
            }
        }
    }
}
