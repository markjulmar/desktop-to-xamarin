using System.Windows;
using System.Windows.Input;

namespace VacationSpots.Infrastructure
{
    public static class MouseBehaviors
    {
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.RegisterAttached(
                "ClickCommand",
                typeof(ICommand),
                typeof(MouseBehaviors),
                new FrameworkPropertyMetadata(null, PropertyChangedCallback));

        public static ICommand GetClickCommand(FrameworkElement fe)
        {
            return (ICommand)fe.GetValue(ClickCommandProperty);
        }

        public static void SetClickCommand(FrameworkElement fe, ICommand value)
        {
            fe.SetValue(ClickCommandProperty, value);
        }

        private static void PropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe != null)
            {
                fe.MouseDown -= FeOnMouseDown;
                if (e.NewValue != null)
                    fe.MouseDown += FeOnMouseDown;
            }
        }

        private static void FeOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ICommand command = GetClickCommand(fe);
            if (command != null && command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}
