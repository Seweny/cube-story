public class ModPlayerCords : ClientMod
{
    public override void OnNewFrameDraw2d(Game game, float deltaTime)
    {
        bool isVisible = false;
        if (!game.keyboardState[game.GetKey(GlKeys.F8)])
            isVisible = !isVisible;

        if (!isVisible)
            return;

        EntityPosition_ playerPos = game.player.position;
        FontCi font = new FontCi();
        font.size = 14;
        
        game.Draw2dText(
            game.platform.StringFormat3("X: {0} Y: {1} Z: {2}", 
            game.platform.FloatToString(playerPos.x),
            game.platform.FloatToString(playerPos.y),
            game.platform.FloatToString(playerPos.z)), 
            font, 
            20, 
            20,
            IntRef.Create(Game.ColorFromArgb(255, 255, 255, 255)), 
            true);
    }

 
}
