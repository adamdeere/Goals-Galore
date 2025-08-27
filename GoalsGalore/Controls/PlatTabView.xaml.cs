using GoalsGalore.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GoalsGalore.Controls;


public partial class PlatTabView : ContentView
{
    private int _previousIndex = 0;

    public PlatTabView()
    {
        InitializeComponent();

        if (Items is INotifyCollectionChanged incc)
            incc.CollectionChanged += (_, __) => Rebuild();

        Loaded += (_, __) =>
        {
            TabHeaderGrid.SizeChanged += (_, ____) => UpdateIndicatorLayout(false, SelectedIndex);
            Rebuild();
        };
    }

    public IList<PlatTabViewItem> Items { get; } = new ObservableCollection<PlatTabViewItem>();

    public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PlatTabView), 0,
            propertyChanged: OnSelectedIndexChanged);

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (PlatTabView)bindable;
        int index = (int)newValue;
        _ = control.SelectTabAsync(index);
    }

    public static readonly BindableProperty TabHeaderTemplateProperty =
        BindableProperty.Create(nameof(TabHeaderTemplate), typeof(DataTemplate), typeof(PlatTabView));

    public DataTemplate TabHeaderTemplate
    {
        get => (DataTemplate)GetValue(TabHeaderTemplateProperty);
        set => SetValue(TabHeaderTemplateProperty, value);
    }

    private void Rebuild()
    {
        TabHeaderGrid.Children.Clear();
        TabHeaderGrid.ColumnDefinitions.Clear();

        if (Items == null || Items.Count == 0)
        {
            TabContent.Content = null;
            Indicator.WidthRequest = 0;
            return;
        }

        for (int i = 0; i < Items.Count; i++)
        {
            TabHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            var headerView = CreateHeaderView(Items[i]);
            headerView.HorizontalOptions = LayoutOptions.Fill;
            headerView.VerticalOptions = LayoutOptions.Fill;

            int index = i;
            var tap = new TapGestureRecognizer { Command = new Command(() => SelectedIndex = index) };
            headerView.GestureRecognizers.Add(tap);

            Grid.SetColumn(headerView, i);
            TabHeaderGrid.Children.Add(headerView);
        }

        if (SelectedIndex < 0 || SelectedIndex >= Items.Count)
            SelectedIndex = 0;

        _ = SelectTabAsync(SelectedIndex);
        UpdateIndicatorLayout(false, SelectedIndex);
    }

    private View CreateHeaderView(PlatTabViewItem item)
    {
        if (TabHeaderTemplate != null)
        {
            var created = TabHeaderTemplate.CreateContent();
            var view = created as View ?? (created as ViewCell)?.View;
            if (view == null)
            {
                view = new Label
                {
                    Text = item.Title,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Colors.White
                };
            }
            view.BindingContext = item;
            //view.Padding = new Thickness(12, 6);
            return view;
        }

        return new Grid
        {
            Padding = new Thickness(12, 6),
            Children =
            {
                new Label
                {
                    Text = string.IsNullOrEmpty(item.Icon?.ToString()) ? item.Title : $"{item.Icon} {item.Title}",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Colors.White,
                    FontAttributes = FontAttributes.Bold
                }
            }
        };
    }

    private async Task SelectTabAsync(int index)
    {
        if (Items == null || Items.Count == 0) return;

        var newContent = Items[index].Content;
        var oldContent = TabContent.Content;

        int direction = index >= _previousIndex ? 1 : -1;

        if (oldContent != null)
        {
            await Task.WhenAll(
                oldContent.FadeTo(0, 140, Easing.CubicIn),
                oldContent.TranslateTo(-20 * direction, 0, 140, Easing.CubicIn)
            );
            TabContent.Content = null;
        }

        if (newContent != null)
        {
            newContent.Opacity = 0;
            newContent.TranslationX = 20 * direction;
            TabContent.Content = newContent;

            await Task.WhenAll(
                newContent.FadeTo(1, 180, Easing.CubicOut),
                newContent.TranslateTo(0, 0, 180, Easing.CubicOut)
            );
        }

        _previousIndex = index;
        UpdateIndicatorLayout(true, index);
    }

    private void UpdateIndicatorLayout(bool animated, int targetIndex)
    {
        if (Indicator == null || TabHeaderGrid == null || Items == null || Items.Count == 0)
            return;

        targetIndex = Math.Clamp(targetIndex, 0, Items.Count - 1);

        double tabWidth = TabHeaderGrid.Width / Items.Count;
        double targetX = targetIndex * tabWidth;

        Indicator.WidthRequest = tabWidth;

        if (animated)
            _ = Indicator.TranslateTo(targetX, 0, 250, Easing.CubicInOut);
        else
            Indicator.TranslationX = targetX;
    }
}
