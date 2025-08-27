namespace GoalsGalore.Model;

[ContentProperty(nameof(Content))]// if you want to omit the <TabItem.Content> tag in XAML.
public partial class PlatTabViewItem : BindableObject
{
    public string Title { get; set; }

    public string Icon { get; set; }
    public string FontFamily { get; set; }

    public static readonly BindableProperty ContentProperty =
                           BindableProperty.Create(nameof(Content),
                                                   typeof(View),
                                                   typeof(PlatTabViewItem),
                                                   default(View));

    public View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}