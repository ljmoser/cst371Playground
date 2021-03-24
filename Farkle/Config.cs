namespace Farkle
{
    public sealed class Config
    {
        private Config()
        {
            //read from config file
        }

        public string ApiKey { get; set; }

        private static Config _ConfigInstance;
        public static Config ConfigInstance
        {
            get
            {
                return _ConfigInstance ??= new Config();
            }
        }
    }
}