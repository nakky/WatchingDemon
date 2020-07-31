using System;

namespace PacketTrigger
{
    public abstract class Plugin
    {
        public abstract string PluginName { get; }

        public abstract short Id { get; }

        public abstract string Description { get; }

        public abstract void Process(string ip, byte[] param);

        bool enable = false;
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }
    }
}
