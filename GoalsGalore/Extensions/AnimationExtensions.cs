namespace GoalsGalore.Extensions;

public static class AnimationExtensions
{
    public static Task WidthRequestTo(this VisualElement element, double newWidth, uint length, Easing easing)
    {
        double startingWidth = element.WidthRequest;
        var tcs = new TaskCompletionSource<bool>();

        new Animation(
            callback: progress => element.WidthRequest = startingWidth + (newWidth - startingWidth) * progress,
            start: 0,
            end: 1
        ).Commit(
            owner: element,
            name: "WidthAnimation",
            length: length,
            easing: easing,
            finished: (v, c) => tcs.SetResult(true)
        );

        return tcs.Task;
    }
}