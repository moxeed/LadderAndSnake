namespace LadderAndSnake.UI
{
    interface IUIAction
    {
        void Render(Game game);
        Game DidRender(Game game);
        IUIAction NextAction();
    }
}
