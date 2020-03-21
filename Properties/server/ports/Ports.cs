namespace SmtpProtocol.Properties.server.ports
{
    /// <summary>
    /// Class hold the main ports for working with such email as Gmail, Yandex.Mail, Mail.ru
    /// <remarks> Correct work only  2 standard port and alternative port </remarks>
    /// </summary>
    public static class Ports
    {
        public static int StandardPort { get; } = 587;
        public static int AlternativeStandardPort { get; } = 25;
        public static int AlternativePort { get; } = 2525;
        public static int GoogleServerPort { get; } = 465;
        public static int YandexPort { get; } = 465;
        public static int MailRuPort { get; } = 465;
    }
}