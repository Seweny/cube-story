using System;


namespace ManicDigger.Mods
{
    class CustomCommands : IMod
    {
        private ModManager m;

        public void PreStart(ModManager m) {}

        public void Start(ModManager m)
        {
            this.m = m;
            m.RegisterOnCommand(HandleCommands);

            
        }

        private bool HandleCommands(int player, string command, string argument)
        {
            if (command.Equals("playerpos"))
            {
                m.SendMessageToAll(String.Format("X: {0} Y: {1} Z: {2}",
                                            (int) m.GetPlayerPositionX(player),
                                            (int) m.GetPlayerPositionY(player),
                                            (int) m.GetPlayerPositionZ(player)));
  
                return true;
            }

            if (command.Equals("spawnbot") && !argument.Equals(""))
            {
                float px = m.GetPlayerPositionX(player);
                float py = m.GetPlayerPositionY(player);
                float pz = m.GetPlayerPositionZ(player);

                int heading = m.GetPlayerHeading(player);
                int pitch = m.GetPlayerPitch(player);
                int stance = m.GetPlayerStance(player);

                int bot = m.AddBot(argument);
                m.SetPlayerPosition(bot, px, py, pz);
                m.SetPlayerOrientation(bot, heading, pitch, stance);

                return true;
            }

            return false;
        }
    }
}
